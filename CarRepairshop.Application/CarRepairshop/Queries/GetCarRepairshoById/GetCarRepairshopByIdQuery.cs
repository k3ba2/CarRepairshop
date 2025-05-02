using MediatR;

namespace CarRepairshop.Application.CarRepairshop.Queries.GetCarRepairshoById
{
    public class GetCarRepairshopByIdQuery : IRequest<CarRepairshopDto>
    {
        public GetCarRepairshopByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
