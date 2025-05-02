using AutoMapper;
using CarRepairshop.Domain.Entities;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CarRepairshop.Application.CarRepairshop.Queries.GetAllCarRepairshop
{
    public class GetAllCarRepairshopQueryHandler : IRequestHandler<GetAllCarRepairshopQuery, IEnumerable<CarRepairshopDto>>
    {
        private readonly CarRepairshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllCarRepairshopQueryHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        async Task<IEnumerable<CarRepairshopDto>> IRequestHandler<GetAllCarRepairshopQuery, IEnumerable<CarRepairshopDto>>.Handle(GetAllCarRepairshopQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var carRepairshop = await _dbContext.CarRepairshops
                .Include(cd => cd.ContactDetails)
                .Include(oph => oph.CarRepairshopOpeningHours)
                .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<CarRepairshopDto>>(carRepairshop);

                if (carRepairshop == null)
                {
                    throw new KeyNotFoundException("Nie udało się pobrać warsztatów samochodowych.");
                }

                return dtos;
            }

            catch (DbUpdateException ex)
            {
                throw new Exception("Wystąpił błąd podczas komunikacji z bazą danych.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił nieoczekiwany błąd podczas pobierania warsztatów samochodowych.", ex);
            }
        }
    }
}
