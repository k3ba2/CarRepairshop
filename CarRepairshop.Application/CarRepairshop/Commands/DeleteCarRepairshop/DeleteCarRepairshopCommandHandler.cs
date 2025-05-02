using AutoMapper;
using CarRepairshop.Domain.Entities;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CarRepairshop.Application.CarRepairshop.Commands.DeleteCarRepairshop
{
    public class DeleteCarRepairshopCommandHandler : IRequestHandler<DeleteCarRepairshopCommand>
    {
        private readonly IMapper _mapper;
        private readonly CarRepairshopDbContext _dbContext;
        public DeleteCarRepairshopCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCarRepairshopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "plik.txt");
                var sixMonthsAgo = DateTime.Now.AddMonths(-6);
                var carRepairshop = await _dbContext.CarRepairshops
                .Where(x => x.CreatedAt <= sixMonthsAgo).ToListAsync();

                if (!carRepairshop.Any())
                {
                    throw new KeyNotFoundException("Brak warsztatów samochodowych do usunięcia.");
                }

                var carRepairshopsCopy = carRepairshop.Select(shop => new ArchivedCarRepairshop
                {
                    CarRepairshopId = shop.Id,
                    Name = shop.Name,
                    DeleteDate = DateTime.UtcNow
                }).ToList();

                string json = JsonSerializer.Serialize(carRepairshopsCopy, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);

                await _dbContext.ArchivedCarRepairshops.AddRangeAsync(carRepairshopsCopy);
                _dbContext.RemoveRange(carRepairshop);
                await _dbContext.SaveChangesAsync();

                return Unit.Value;

            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Błąd podczas usuwania warsztatu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił nieoczekiwany błąd.", ex);
            }
        }
    }
}
