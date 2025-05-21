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

        [HttpGet("GetAllState")]
        public IActionResult GetAllState()
        {
            return Ok(_state.GetAllState());
        }

        [HttpGet("GetStateById/{id}")]
        public IActionResult GetState(int id)
        {
            var state = _state.GetStateById(id);
            if (state == null)
                return NotFound($"State with ID {id} not found.");

            return Ok(state);
        }

        [HttpPut("UpdateState/{id}")]
        public IActionResult UpdateState(int id, State state)
        {
            if (state == null || state.Id != id)
                return BadRequest("Invalid state data.");
            var result = _state.UpdateState(state);
            return Ok("state updated successfully.");

        }

        [HttpPost("AddState")]
        public IActionResult AddState(State state)
        {
            if (state == null)
                return BadRequest("Invalid state data.");
            var result = _state.AddState(state);
            return Ok("state added successfully.");
        }

        [HttpDelete("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            var result = _state.DeleteState(id);
            return Ok("State deleted successfully.");
        }

    }
}