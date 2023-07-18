using AnagramDreams.Api.Dtos;
using AnagramDreams.DataAccess.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnagramDreams.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;

        public GamesController(
            IMapper mapper,
            IGameService gameService)
        {
            this.gameService = gameService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GameResp>> NewGame([FromBody] GameReq game)
        {
            try
            {
                var result = await gameService.NewGame(game.WordCount, game.GameTime, game.AnagramCount);
                return Ok(mapper.Map<GameResp>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
