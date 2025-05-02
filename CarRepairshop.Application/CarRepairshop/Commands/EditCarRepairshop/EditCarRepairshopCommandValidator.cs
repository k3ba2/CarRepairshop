using Azure.Core;
using CarRepairshop.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop.Commands.EditCarRepairshop
{
    public class EditCarRepairshopCommandValidator : AbstractValidator<EditCarRepairshopCommand>
    {
        public EditCarRepairshopCommandValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(2).WithMessage("Pole musi mieć co najmniej 2 znaki.")
                .MaximumLength(160).WithMessage("Pole nie może mieć więcej niż 160 znaków.")
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.About)
                .MaximumLength(50).WithMessage("Pole nie może mieć więcej niż 50 znaków.");

            RuleFor(x => x.PhoneNumber)
                .Length(9).WithMessage("Numet telefonu musi mieć 9 znaków.")
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.Street)
                .MaximumLength(30).WithMessage("Pole nie może zawierać więcej niż 30 znaków")
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.City)
                .MaximumLength(30).WithMessage("Pole nie może zawierać więcej niż 30 znaków")
                .NotEmpty().WithMessage("Pole nie może być puste");


            string pattern = @"^\d{2}-\d{3}$";

            RuleFor(x => x.PostalCode)
                .Matches(pattern).WithMessage("Pole musi zawierać 5 cyfr.")
                .NotEmpty().WithMessage("Pole nie może być puste");
        }
    }
}
