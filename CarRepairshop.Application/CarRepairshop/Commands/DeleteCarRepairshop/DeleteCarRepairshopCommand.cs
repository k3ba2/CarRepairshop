using AutoMapper;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRepairshop.Application.CarRepairshop.Commands.DeleteCarRepairshop
{
    public class DeleteCarRepairshopCommand : Domain.Entities.CarRepairshop, IRequest
    {
      
    }
}
