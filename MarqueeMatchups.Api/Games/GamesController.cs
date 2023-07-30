using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Games;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MarqueeMatchups.Api.Games
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
       

        private readonly ILogger<GamesController> _logger;
        private readonly IGameRepository _gameRepository;

        public GamesController(ILogger<GamesController> logger,IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpGet(Name = "GetGames")]
        public IEnumerable<Game> Get()
        {
            return _gameRepository.GetAll();
        }

        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [HttpGet("{id}",Name = "GetGameById")]
        public IActionResult Get(int id)
        {
            var game =  _gameRepository.GetById(id);
            if(game == null)
            {
                return new NotFoundResult();
            }
            return new JsonResult(game);
    
        }
    }
}