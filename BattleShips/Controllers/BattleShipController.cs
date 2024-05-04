using AutoMapper;
using BattleShip.Service;
using BattleShips.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BattleShips.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly IBattleShipService _battleshipService;
        private readonly IMapper _mapper;

        public BattleShipController(IBattleShipService battleshipService, IMapper mapper)
        {
            _battleshipService = battleshipService;
            _mapper = mapper;
        }

        [HttpPost,Route("createbattleship")]
        [ProducesDefaultResponseType(typeof(bool))]
        public async Task<IActionResult> CreateBattleShip([FromBody] GridDto gridDto )
        {
            try
            {
                var result = await _battleshipService.CreateBattleShip(gridDto.SizeX, gridDto.SizeY);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Error - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("fire")]
        [ProducesDefaultResponseType(typeof(bool))]
        public async Task<IActionResult> Fire([FromBody] GridLocationDto gridLocationDto)
        {
            try
            {
                var result = await _battleshipService.Fire(gridLocationDto.X, gridLocationDto.Y);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Error - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("getsunkshipdetails")]
        [ProducesDefaultResponseType(typeof(ShipDto))]
        public async Task<IActionResult> GetSunkShipDetails()
        {
            try
            {
                var result = await _battleshipService.GetSunkShipDetails();
                var mapped = _mapper.Map<List<ShipDto>>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Error - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("GetBattleshipDetails")]
        [ProducesDefaultResponseType(typeof(ShipDto))]
        public async Task<IActionResult> GetBattleshipDetails()
        {
            try
            {
                var result = await _battleshipService.GetBattleshipDetails();
                var mapped = _mapper.Map<List<ShipDto>>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Error - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
