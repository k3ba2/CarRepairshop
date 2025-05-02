using MediatR;
using CarRepairshop.Application.CarRepairshop.Queries.GetCarRepairshoById;
using CarRepairshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CarRepairshop.Application.CarRepairshop.Queries.GetCarRepairshoById
{
    public class GetCarRepairshopByIdQueryHandler : IRequestHandler<GetCarRepairshopByIdQuery, CarRepairshopDto>
    {

        private readonly CarRepairshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCarRepairshopByIdQueryHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CarRepairshopDto> Handle(GetCarRepairshopByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var carRepairshop = await _dbContext.CarRepairshops
                .Include(cd => cd.ContactDetails)
                .Include(oph => oph.CarRepairshopOpeningHours)
                .FirstOrDefaultAsync(id => id.Id == request.Id, cancellationToken);

                if (carRepairshop == null)
                {
                    throw new KeyNotFoundException("Nie udało się pobrać warsztatu samochodowego.");
                }

                var dtos = _mapper.Map<CarRepairshopDto>(carRepairshop);

                return dtos;
            }

            catch (DbUpdateException ex)
            {
                throw new Exception("Wystąpił błąd podczas komunikacją z bazą danych.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił nieoczekiwany błąd podczas pobierania warsztatu samochodowego.", ex);
            }
        }
    }
}
