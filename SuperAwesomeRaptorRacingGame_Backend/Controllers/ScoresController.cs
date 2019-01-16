using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SuperAwesomeRaptorRacingGame_Backend.Dtos;
using SuperAwesomeRaptorRacingGame_Backend.Entities;
using SuperAwesomeRaptorRacingGame_Backend.Helpers;
using SuperAwesomeRaptorRacingGame_Backend.Services;

namespace SuperAwesomeRaptorRacingGame_Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private IUserService _userService;
        private IScoreService _scoreService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ScoresController(
            IScoreService scoreService,
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _scoreService = scoreService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }




        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScore([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var score = await _scoreService.GetScoreById(id);

            if (score == null)
           {
                return NotFound();
          }

          return Ok(score);
        }

        // GET: api/Scores/top/Racetrack01
        [HttpGet("top/{trackName}")]
        public async Task<IActionResult> GetTopScoreForTrack([FromRoute] string trackName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topScoreForTrack = await _scoreService.GetTopScoreByTrack(trackName);

            if (topScoreForTrack == null)
            {
                return NotFound();
            }

            return Ok(topScoreForTrack);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScores()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var scores = await _scoreService.GetAllScores();
            return Ok(scores);
        }


        [HttpGet("uid/{uid}")]
        public async Task<IActionResult> getScoresByUserId([FromRoute] int uid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var scores = await _scoreService.GetScoresForUser(uid);
            return Ok(scores);
        }



        // POST: api/Scores
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostScore([FromBody] ScoreDto scoreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // map dto to entity
            var score = _mapper.Map<Score>(scoreDto);
            var user = _userService.GetByUsername(scoreDto.Username);
            score.User = user;
            _scoreService.AddScore(score);
            
            return Ok(score);
        }

       
    }
}