using AutoMapper;
using CarRepairshop.Domain.Entities;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop.Commands.QueuingSystem
{
    public class QueuingSystemCommandHandler : IRequestHandler<QueuingSystemCommand>
    {
        private readonly CarRepairshopDbContext _dbContext;

        public QueuingSystemCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(QueuingSystemCommand request, CancellationToken cancellationToken)
        {
            var customer = request.CustomerId;
            var startTime = request.StartTime;
            var endTime = request.EndTime;
            var service = request.ServiceId;

            var appointmentIsExist = _dbContext.Appointments;

            if (!appointmentIsExist.Any())
            {
                var newAppointment = new Appointment
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    CustomerId = customer,
                    ServiceId = service
                };

                _dbContext.Appointments.Add(newAppointment);
            } else
            {
                bool makeAppointment = _dbContext.Appointments.Any(
                    x => x.CustomerId == customer &&
                    x.ServiceId == service &&
                    (x.StartTime >= endTime ||
                    x.EndTime <= startTime));

                if (!makeAppointment)
                {
                    throw new KeyNotFoundException("Masz już umówioną podaną usługę w podanym przedziale czasowym.");
                }
                else
                {
                    var newAppointment = new Appointment
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        CustomerId = customer,
                        ServiceId = service
                    };

                    _dbContext.Appointments.Add(newAppointment);
                };
            };

                

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
