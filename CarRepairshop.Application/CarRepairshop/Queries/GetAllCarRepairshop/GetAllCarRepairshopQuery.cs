using MediatR;

namespace CarRepairshop.Application.CarRepairshop.Queries.GetAllCarRepairshop
{
    public class GetAllCarRepairshopQuery : IRequest<IEnumerable<CarRepairshopDto>>
    {
    }
}
