using AutoMapper;
using CarRepairshop.Application.CarRepairshop.Commands.CreateCarRepairshop;
using CarRepairshop.Application.CarRepairshop.Commands.DeleteCarRepairshop;
using CarRepairshop.Application.CarRepairshop.Commands.EditCarRepairshop;
using CarRepairshop.Application.CarRepairshop.Queries.GetAllCarRepairshop;
using CarRepairshop.Application.CarRepairshop.Queries.GetCarRepairshoById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairshop.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRepairshopController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarRepairshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("CarRepairshop")]
        public async Task<IActionResult> Index()
        {
            var carRepairshop = await _mediator.Send(new GetAllCarRepairshopQuery());

            if (carRepairshop == null)
            {
                return NotFound($"Brak warsztatów do wyświetlenia.");
            }

            return Ok(carRepairshop);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarRepairshopById(int id)
        {
            var command = new GetCarRepairshopByIdQuery(id);
            var carRepairshop = await _mediator.Send(command);

            if(carRepairshop == null)
            {
                return NotFound($"Nie znaleziono warsztatu o podanym id: {id}.");
            }

            return Ok(carRepairshop);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCarRepairshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carRepairshop = await _mediator.Send(command);
            return Ok(carRepairshop);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCarRepairshopCommand command)
        {
            command.Id = id;

            var carRepairshop = await _mediator.Send(command);
            return Ok(carRepairshop);
        }

        [HttpDelete("delete/OldCarRepairshops")]
        public async Task<IActionResult> DeleteOldCarRepairshop()
        {
            var carRepairshop = await _mediator.Send(new DeleteCarRepairshopCommand());
            return Ok(carRepairshop);
        }

    }
}
