﻿using FluentValidation;
using Multishop.Catalog.Dtos.AdvertisementDtos;

namespace Multishop.Catalog.ValidationRules.AdvertisementValidationRules
{
    public class AdvertisementUpdateValidator : AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateValidator()
        {
            RuleFor(advertisement => advertisement.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(advertisement => advertisement.Title)
               .NotEmpty().WithMessage("Please enter a title !")
               .MinimumLength(3).WithMessage("Title can not be less than 3 characters !")
               .MaximumLength(50).WithMessage("Title can not be greater than 50 characters !");

            RuleFor(advertisement => advertisement.Description)
                .NotEmpty().WithMessage("Please enter a description !")
                .MinimumLength(3).WithMessage("Description can not be less than 3 characters !")
                .MaximumLength(100).WithMessage("Description can not be greater than 100 characters !");

            RuleFor(advertisement => advertisement.ImageUrl)
                .NotEmpty().WithMessage("Please enter a image url !")
                .MinimumLength(3).WithMessage("Image url can not be less than 3 characters !")
                .MaximumLength(250).WithMessage("Image url can not be greater than 250 characters !");

            RuleFor(advertisement => advertisement.IsActive)
               .NotEmpty().WithMessage("Advertisement active value can not be null or empty !");
        }
    }
}