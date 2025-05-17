using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _state;

        public StateController(IState state)
        {
            _state = state;
        }

        [HttpGet("GetAllStates")]
        public IActionResult GetAllStates()
        {
            return Ok(_state.GetAll());
        }

        [HttpGet("GetStateById/{id}")]
        public IActionResult GetStateById(int id)
        {
            var result = _state.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddState")]
        public IActionResult AddState(State state)
        {
            return Ok(_state.Add(state));
        }

        [HttpPut("UpdateState")]
        public IActionResult UpdateState(State state)
        {
            return Ok(_state.Update(state));
        }

        [HttpDelete("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            return Ok(_state.Delete(id));
        }
    }
}
