using EventAPI.Features.Event.AddEvent;
using EventAPI.Features.Event.DeleteEvent;
using EventAPI.Features.Event.GetEvents;
using EventAPI.Features.Event.UpdateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event
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
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="200">Возвращён список мероприятий</response>
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
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="400">Ошибка валидации/</response>
        /// <response code="200">Мероприятие успешно добавлено</response>
        [HttpPost]
        public async Task<ActionResult> PostEvent([FromBody] Event eEvent)
        {
            var result = await _mediator.Send(new AddEventCommand(eEvent));
            if (result.Error == null)
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
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="401">Ошибка валидации/</response>
        /// <response code="400">Id в запросе не совпадают</response>
        /// <response code="200">Мероприятие успешно изменено</response>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(Guid id, [FromBody] Event eEvent)
        {
            if (id == eEvent.Id)
            {
                var result = await _mediator.Send(new UpdateEventCommand(eEvent));
                if (result.Error == null)
                    return StatusCode(201);
                else
                    return StatusCode(401, result);
            }
            else
            {
                ScError scError = new();
                scError.Message = "Id не совпадают";
                return StatusCode(400, new ScResult(scError));
            }
        }

        /// <summary>
        /// Удаление мероприятия из базы данных
        /// </summary>
        /// <param name="id">Id мероприятия</param>
        /// <returns>Результат удаления объекта</returns>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="400">Мероприятия с таким Id не существует</response>
        /// <response code="200">Мероприятие успешно удалено</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(Guid id)
        {
            var result = await _mediator.Send(new DeleteEventCommand(id));
            if (result.Error == null)
                return Ok();
            else
                return BadRequest(result);
        }
    }
}
