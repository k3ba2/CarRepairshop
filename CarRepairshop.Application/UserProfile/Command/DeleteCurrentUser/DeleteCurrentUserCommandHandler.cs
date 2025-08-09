using AutoMapper;
using CarRepairshop.Infrastructure.Persistance;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace CarRepairshop.Application.UserProfile.Command.DeleteCurrentUser
{
    public class DeleteCurrentUserCommandHandler : IRequestHandler<DeleteCurrentUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly CarRepairshopDbContext _dbContext;
        public DeleteCurrentUserCommandHandler(CarRepairshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCurrentUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.Id;

            var userToDelete = await _dbContext.Users.FindAsync(userId);

            if (userToDelete == null)
            {
                throw new NotFoundException("User not found");
            }

            _dbContext.Remove(userToDelete);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
