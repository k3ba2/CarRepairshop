using AutoMapper;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CarRepairshop.Application.CarRepairshop.Commands.EditCarRepairshop
{
    public class EditCarRepairshopCommandHandler : IRequestHandler<EditCarRepairshopCommand>
    {
        private readonly IMapper _mapper;
        private readonly CarRepairshopDbContext _dbContext;

        public EditCarRepairshopCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditCarRepairshopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carRepairshop = await _dbContext.CarRepairshops
                .Include(cd => cd.ContactDetails)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

                if (carRepairshop == null)
                {
                    throw new KeyNotFoundException($"Warsztat samochodowy o id {request.Id} nie istnieje.");
                }

                carRepairshop.Description = request.Description;
                carRepairshop.About = request.About;

                carRepairshop.ContactDetails.PhoneNumber = request.PhoneNumber;
                carRepairshop.ContactDetails.Street = request.Street;
                carRepairshop.ContactDetails.City = request.City;
                carRepairshop.ContactDetails.PostalCode = request.PostalCode;

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Błąd podczas zapisu edycji warsztatu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił nieoczekiwany błąd edycji", ex);
            }
        }
    }
}
