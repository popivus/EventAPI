using EventAPI.Features.Ticket.AddTicket;
using EventAPI.Features.Ticket.CheckUserTicket;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Features.Ticket
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавление билета на мероприятие
        /// </summary>
        /// <param name="idEvent">Id мероприятия</param>
        /// <param name="ticket">Билет</param>
        /// <returns>Ответ сервера</returns>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="400">Мероприятия с таким Id не существует</response>
        /// <response code="401">На мероприятии кончились свободные места</response>
        /// <response code="200">Билет успешно добавлен на мероприятие</response>
        [HttpPost("{idEvent}")]
        public async Task<ActionResult> PostTicket(Guid idEvent, [FromBody] Ticket ticket)
        {
            var result = await _mediator.Send(new AddTicketCommand(ticket, idEvent));
            if (result.Error != null)
            {
                if (result.Error.Message == "Мероприятия с таким Id не существует")
                    return StatusCode(400, result);
                else
                    return StatusCode(401, result);
            }
            else
                return Ok();
        }

        /// <summary>
        /// Проверка наличие у пользователя билета на мероприятие
        /// </summary>
        /// <param name="idEvent">Id мероприятия</param>
        /// <param name="idUser">Id проверяемого пользователя</param>
        /// <returns>Ответ, существует ли билет</returns>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="400">Мероприятия с таким Id не существует</response>
        /// <response code="200">Ответ true/false, существует ли такой билет</response>
        [HttpGet("{idEvent}/{idUser}")]
        public async Task<ActionResult> CheckUserTicket(Guid idEvent, Guid idUser)
        {
            var result = await _mediator.Send(new CheckUserTicketQuery(idUser, idEvent));
            if (result.Error == null)
                return Ok(true);
            else if (result.Error.Message == "Такого мероприятия не существует")
                return BadRequest(result);
            else
                return Ok(false);
        }
    }
}
