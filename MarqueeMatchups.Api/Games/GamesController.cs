using MarqueeMatchups.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MarqueeMatchups.Api.Matches
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
       

        private readonly ILogger<GamesController> _logger;
        private readonly GameRepository _gameRepository;

        public GamesController(ILogger<GamesController> logger,GameRepository gameRepository)
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