using FluentValidation;
using Service.Handlers.ProductDetails.Command;

namespace Service.Common.Validators.ProductDetails
{
    public class UpdateProductDetailCommandValidator : AbstractValidator<UpdateProductDetailCommand>
    {
        public UpdateProductDetailCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("");
            RuleFor(x => x.idMaterial).NotEmpty().WithMessage("");
            RuleFor(x => x.idCategory).NotEmpty().WithMessage("");
            RuleFor(x => x.idProduct).NotEmpty().WithMessage("");
            RuleFor(x => x.idBrand).NotEmpty().WithMessage("");
            RuleFor(x => x.idColor).NotEmpty().WithMessage("");
            RuleFor(x => x.idSize).NotEmpty().WithMessage("");
            RuleFor(x => x.Price).NotNull().WithMessage("");
            RuleFor(x => x.Quantity).NotNull().WithMessage("");
        }
    }
}

