using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroSevice;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }



        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHeroes(int id)
        {
            var result = await _superHeroService.GetSingleHeroes(id);
            if (result is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id,request);
            if (result is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
    
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id, SuperHero request)
        {
            var result = await _superHeroService.DeleteHero(id,request);
            if (result is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(result);
        }
    }
}

