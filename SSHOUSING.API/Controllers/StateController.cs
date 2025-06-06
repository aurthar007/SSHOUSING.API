﻿using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _state;
        private readonly ApplicationDbContext _context;  

        public StateController(IState state, ApplicationDbContext context)
        {
            _state = state;
            _context = context; 
        }

        [HttpGet("GetAllState")]
        public IActionResult GetAllState()
        {
            var states = _state.GetAllState();
            var StateDTO = states.Select(s => new StateDTO
            {
                Id = s.Id,
                CountryId = s.CountryId,
                Name = s.Name
            }).ToList();

            return Ok(StateDTO);
        }

        [HttpGet("GetStateById/{id}")]
        public IActionResult GetState(int id)
        {
            var state = _state.GetStateById(id);
            if (state == null)
                return NotFound($"State with ID {id} not found.");

            var StateDTO = new StateDTO
            {
                Id = state.Id,
                CountryId = state.CountryId,
                Name = state.Name
            };

            return Ok(StateDTO);
        }

        [HttpPut("UpdateState/{id}")]
        public IActionResult UpdateState(int id, StateDTO stateDto)
        {
            if (stateDto == null || id != stateDto.Id)
                return BadRequest("Invalid state data.");

            if (!_context.Countries.Any(c => c.Id == stateDto.CountryId))
                return BadRequest("Invalid CountryId.");

            var state = _state.GetStateById(id);
            if (state == null)
                return NotFound($"State with ID {id} not found.");

            state.Name = stateDto.Name;
            state.CountryId = stateDto.CountryId;

            var result = _state.UpdateState(state);
            return Ok("State updated successfully.");
        }

        [HttpPost("AddState")]
        public IActionResult AddState(StateDTO stateDto)
        {
            if (stateDto == null)
                return BadRequest("Invalid state data.");

              if (!_context.Countries.Any(c => c.Id == stateDto.CountryId))
                return BadRequest("Invalid CountryId.");

            var state = new State
            {
                CountryId = stateDto.CountryId,
                Name = stateDto.Name
            };

            var result = _state.AddState(state);
            return Ok("State added successfully.");
        }

        [HttpDelete("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            var result = _state.DeleteState(id);
            if (!result)
                return NotFound($"State with ID {id} not found.");

            return Ok("State deleted successfully.");
        }
    }
}
