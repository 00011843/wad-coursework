using EventHubAPI.Models;
using EventHubAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/<EventsController>
        [HttpGet]

        public IActionResult Get()
        {
            return new OkObjectResult(_eventRepository.GetAllEvents());
        }



        // GET api/categories/2
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int Id)
        {
            return new OkObjectResult(_eventRepository.GetEventById(Id));
        }

        // POST api/<EventsController>
        [HttpPost]
        public IActionResult CreateNewEvent(Event ev)
        {
            using (var scope = new TransactionScope())
            {
                _eventRepository.CreateNewEvent(ev);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { Id = ev.Id });
            }
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEvent([FromBody] Event ev)
        {
            if (ev != null)
            {
                using (var scope = new TransactionScope())
                {
                    _eventRepository.UpdateEvent(ev);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCateogry(int Id)
        {
            _eventRepository.DeleteEventById(Id);
            return new OkResult();
        }
    }
}
