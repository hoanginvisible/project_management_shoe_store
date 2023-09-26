using Application.Handlers.ProductDetail.Command;
using FluentValidation;

namespace Service.Common.Validator
{
    public class AddProductDetailCommandValidator : AbstractValidator<CreateProductDetailCommand>
    {
        public AddProductDetailCommandValidator()
        {
            RuleFor(x => x.idProduct).NotEmpty().WithMessage(" Vui lòng chọn Product");
            RuleFor(x => x.Quantity).GreaterThan(4).WithMessage(" Vui lòng nhập số to hơn 4");
        }
    }
}