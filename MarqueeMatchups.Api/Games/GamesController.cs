using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Data.DTO;
using MarqueeMatchups.Api.Games;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
        [HttpGet(Name = "GetGames")]
        public async Task<IActionResult> Get([FromQuery]SportValues sportId = SportValues.Football)
        {
            ICollection<Game> games = new List<Game>();
            
            games = await _gameRepository.GetFutureGamesBySportAsync(sportId);

            return new JsonResult(
                games.OrderBy(x => x.ScheduledAt).ToList()
                );
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


        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [HttpPost(Name = "CreateGame")]
        public IActionResult Create([FromBody] GameDto data)
        {
            var game = _gameRepository.Create(data);
            
            if (game == null)
            {
                return new NotFoundResult();
            }
            return new JsonResult(game);

        }
    }
}