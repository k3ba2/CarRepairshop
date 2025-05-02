using AutoMapper;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRepairshop.Application.CarRepairshop.Commands.CreateCarRepairshop
{
    public class CreateCarRepairshopCommandHandler : IRequestHandler<CreateCarRepairshopCommand>
    {
        private readonly IMapper _mapper;
        private readonly CarRepairshopDbContext _dbContext;

        public CreateCarRepairshopCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCarRepairshopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carRepairshop = _mapper.Map<Domain.Entities.CarRepairshop>(request);

                if (carRepairshop == null)
                {
                    throw new KeyNotFoundException("Nie udało się utworzyć warsztatu samochodowego.");
                }

                carRepairshop.EncodeName();

                _dbContext.CarRepairshops.Add(carRepairshop);
                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }

            catch (DbUpdateException ex)
            {
                throw new Exception("Wystąpił błąd podczas zapisu do bazy danych.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił nieoczekiwany błąd podczas tworzenia nowego warsztatu.", ex);
            }
            }
        }
    }
