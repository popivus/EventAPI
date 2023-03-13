using EventAPI.Commands;
using EventAPI.Models;
using EventAPI.Models.Interfaces;
using EventAPI.Queries;
using EventAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Получение коллекции всех существующих мероприятий
        /// </summary>
        /// <returns>Коллекция мероприятий</returns>
        [HttpGet]
        public async Task<IEnumerable<IEvent>> GetEvents()
        {
            var events = await _mediator.Send(new GetEventsQuery());
            return events;
        }
        
        /// <summary>
        /// Добавление нового мероприятия в базу данных
        /// </summary>
        /// <param name="eEvent">Объект мероприятия</param>
        /// <returns>Результат добавления объекта</returns>
        [HttpPost]
        public async Task<ActionResult> PostEvent([FromBody] Event eEvent)
        {
            var result = await _mediator.Send(new AddEventCommand(eEvent));
            if (result.Count() == 0)
                return StatusCode(201);
            else
                return BadRequest(result);
        }

        /// <summary>
        /// Изменение уже существующего мероприятия
        /// </summary>
        /// <param name="id">Id мероприятия</param>
        /// <param name="eEvent">Изменяемый объект мероприятия</param>
        /// <returns>Результат изменения объекта</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(Guid id, [FromBody] Event eEvent)
        {
            if (id == eEvent.Id)
            {
                var result = await _mediator.Send(new UpdateEventCommand(eEvent));
                if (result.Count() == 0)
                    return StatusCode(201);
                else
                    return BadRequest(result);
            }
            else
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Удаление мероприятия из базы данных
        /// </summary>
        /// <param name="id">Id мероприятия</param>
        /// <returns>Результат удаления объекта</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(Guid id)
        {
            var result = await _mediator.Send(new DeleteEventCommand(id));
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
