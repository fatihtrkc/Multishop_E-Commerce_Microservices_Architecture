﻿using FluentValidation;
using Multishop.Discount.Dtos;

namespace Multishop.Discount.ValidationRules.CouponValidationRules
{
    public class CouponUpdateValidator : AbstractValidator<CouponUpdateDto>
    {
        public CouponUpdateValidator()
        {
            RuleFor(coupon => coupon.Code)
                .NotEmpty().WithMessage("Please enter code !")
                .MinimumLength(1).WithMessage("Minimum one character is entered this code field !")
                .MaximumLength(50).WithMessage("Maximum fifty characters is entered this code field !");

            RuleFor(coupon => coupon.Rate)
                .GreaterThan(0).WithMessage("Discount rate must be greater than zero !")
                .LessThanOrEqualTo(100).WithMessage("Discount rate must be less than or equal to 100 !");

            RuleFor(coupon => coupon.ExpirationDate)
                .GreaterThan(DateTime.Now).WithMessage("Expiration date must be later than now !");
        }
    }
}