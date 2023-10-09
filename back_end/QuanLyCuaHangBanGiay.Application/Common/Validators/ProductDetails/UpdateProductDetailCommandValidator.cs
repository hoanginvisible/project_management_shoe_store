using FluentValidation;
using Service.Handlers.ProductDetails.Command;

namespace Service.Common.Validators.ProductDetails
{
    public class UpdateProductDetailCommandValidator : AbstractValidator<UpdateProductDetailCommand>
    {
        public UpdateProductDetailCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("");
            RuleFor(x => x.IdMaterial).NotEmpty().WithMessage("");
            RuleFor(x => x.IdCategory).NotEmpty().WithMessage("");
            RuleFor(x => x.IdProduct).NotEmpty().WithMessage("");
            RuleFor(x => x.IdBrand).NotEmpty().WithMessage("");
            RuleFor(x => x.IdColor).NotEmpty().WithMessage("");
            RuleFor(x => x.IdSize).NotEmpty().WithMessage("");
            RuleFor(x => x.Price).NotNull().WithMessage("");
            RuleFor(x => x.Quantity).NotNull().WithMessage("");
        }
    }
}

