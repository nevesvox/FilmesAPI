using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    // Utiliza o nome do controller como rota
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        // Rota post
        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto cinema = _cinemaService.AddCinema(cinemaDto);
            return CreatedAtAction(nameof(GetCinema), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult GetCinemas([FromQuery] string nomeFilme)
        {
            List<ReadCinemaDto> cinemas = _cinemaService.GetCinemas(nomeFilme);
            if (cinemas != null)
            {
                return Ok(cinemas);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetCinema(int id)
        {
            ReadCinemaDto cinema = _cinemaService.GetCinema(id);
            if (cinema != null)
            {
                return Ok(cinema);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema([FromBody] UpdateCinemaDto cinameDto, int id)
        {
            ReadCinemaDto cinema = _cinemaService.UpdateCinema(cinameDto, id);
            if (cinema != null)
            {
                return Ok(cinema);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var res = _cinemaService.DeleteCinema(id);
            if (res.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
