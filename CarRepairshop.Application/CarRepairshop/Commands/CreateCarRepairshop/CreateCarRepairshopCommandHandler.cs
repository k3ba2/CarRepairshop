using AutoMapper;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System.Security.Claims;

namespace CarRepairshop.Application.CarRepairshop.Commands.CreateCarRepairshop
{
    public class CreateCarRepairshopCommandHandler : IRequestHandler<CreateCarRepairshopCommand>
    {
        private readonly IMapper _mapper;
        private readonly CarRepairshopDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateCarRepairshopCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(CreateCarRepairshopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userClaims = _httpContextAccessor.HttpContext?.User
                    ?? throw new UnauthorizedAccessException("Brak danych użytkownika.");

                var userRole = userClaims.FindFirstValue(ClaimTypes.Role);
                
                if(userRole != "Admin")
                {
                    throw new ForbiddenException("Brak wymaganych uprawnień");
                }

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
