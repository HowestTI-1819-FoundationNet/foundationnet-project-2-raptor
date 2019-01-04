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

           // var score = await _context.Scores.FindAsync(id);

          //  if (score == null)
         //   {
                return NotFound();
         //   }

          //  return Ok(score);
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

            _scoreService.AddScore(score);
            // var user = _context.Users.Where(u => u.UserId == scoreDto.UserId);

            // _context.Scores.Add(score);
            //await _context.SaveChangesAsync();

            return Ok();
        }

       
    }
}