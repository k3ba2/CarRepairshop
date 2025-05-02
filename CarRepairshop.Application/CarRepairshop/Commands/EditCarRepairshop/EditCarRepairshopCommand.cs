using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop.Commands.EditCarRepairshop
{
    public class EditCarRepairshopCommand : CarRepairshopDto , IRequest
    {
        public EditCarRepairshopCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
