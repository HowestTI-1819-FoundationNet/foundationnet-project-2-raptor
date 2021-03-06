﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SuperAwesomeRaptorRacingGame_Backend.Dtos;
using SuperAwesomeRaptorRacingGame_Backend.Entities;
using SuperAwesomeRaptorRacingGame_Backend.Helpers;
using SuperAwesomeRaptorRacingGame_Backend.Hubs;
using SuperAwesomeRaptorRacingGame_Backend.Services;

namespace SuperAwesomeRaptorRacingGame_Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IHubContext<ScoresNotifyHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly IScoreRepository _scoreRepository;
        private readonly IUserRepository _userRepository;

        public ScoresController(
            IScoreRepository scoreRepository,
            IUserRepository userRepository,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IHubContext<ScoresNotifyHub> hubContext)
        {
            _userRepository = userRepository;
            _scoreRepository = scoreRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _hubContext = hubContext;
        }


        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScore([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var score = await _scoreRepository.GetScoreById(id);

            if (score == null) return NotFound();

            return Ok(score);
        }

        // GET: api/Scores/top/Racetrack01
        [HttpGet("top/{trackName}")]
        public async Task<IActionResult> GetTopScoreForTrack([FromRoute] string trackName)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var topScoreForTrack = await _scoreRepository.GetTopScoreByTrack(trackName);

            if (topScoreForTrack == null) return NotFound();

            return Ok(topScoreForTrack);
        }

        [HttpGet]
        [AllowAnonymous] // front end needs a list without a JWT token
        public async Task<IActionResult> GetAllScores()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var scores = await _scoreRepository.GetAllScores();
            return Ok(scores);
        }


        [HttpGet("uid/{uid}")]
        public async Task<IActionResult> GetScoresByUserId([FromRoute] int uid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var scores = await _scoreRepository.GetScoresForUser(uid);
            return Ok(scores);
        }


        // POST: api/Scores
        [HttpPost]
        public async Task<IActionResult> PostScore([FromBody] ScoreDto scoreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // map dto to entity
            var score = _mapper.Map<Score>(scoreDto);
            var user = _userRepository.GetByUsername(scoreDto.Username);
            score.User = user;
            await _scoreRepository.AddScore(score);
            await _hubContext.Clients.All.SendAsync("scoresUpdate", scoreDto);
            return Ok(score);
        }
    }
}