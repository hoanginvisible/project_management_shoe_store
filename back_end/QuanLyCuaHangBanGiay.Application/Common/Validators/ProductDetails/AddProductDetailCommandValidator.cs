using FluentValidation;
using Service.Handlers.ProductDetails.Command;

namespace Service.Common.Validators.ProductDetails
{
    public class AddProductDetailCommandValidator : AbstractValidator<CreateProductDetailCommand>
    {
        public AddProductDetailCommandValidator()
        {
            RuleFor(x => x.idProduct).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idBrand).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idCategory).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idColor).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idImage).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idMaterial).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.idSize).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.Price).NotNull().WithMessage("Vui lòng nhập dữ liệu đầy đủ").Must(x =>
            {
                if (x is Double)
                {
                    return true;
                }

                if (x > 0)
                {
                    return true;
                }

                return false;
            }).WithMessage("Giá là kiểu số và phải lớn hơn 0");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Vui lòng nhập dữ liệu đầy đủ").Must(x =>
            {
                if (x is long && x > 0)
                {
                    return true;
                }

                return false;
            }).WithMessage("Số lượng là kiểu số và lớn hơn 0");
        }
    }
}