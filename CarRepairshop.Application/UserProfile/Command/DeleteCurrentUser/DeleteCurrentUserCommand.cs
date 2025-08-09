using MediatR;

namespace CarRepairshop.Application.UserProfile.Command.DeleteCurrentUser
{
    public class DeleteCurrentUserCommand : IRequest
    {
        public DeleteCurrentUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
