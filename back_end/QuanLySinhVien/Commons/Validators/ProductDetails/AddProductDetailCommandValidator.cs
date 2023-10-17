using FluentValidation;
using Service.Handlers.ProductDetails.Command;

namespace QuanLyCuaHangBanGiay.Commons.Validators.ProductDetails
{
    public class AddProductDetailCommandValidator : AbstractValidator<CreateProductDetailCommand>
    {
        public AddProductDetailCommandValidator()
        {
            RuleFor(x => x.IdProduct).NotEmpty().WithMessage("Sản phẩm không để trống");
            RuleFor(x => x.IdBrand).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.IdCategory).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.IdColor).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.IdMaterial).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.IdSize).NotEmpty().WithMessage("Vui lòng nhập dữ liệu đầy đủ");
            RuleFor(x => x.Price).NotNull().WithMessage("Vui lòng nhập dữ liệu đầy đủ").Must(x => x is > 0).WithMessage("Giá là kiểu số và phải lớn hơn 0");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Vui lòng nhập dữ liệu đầy đủ").Must(x => x > 0).WithMessage("Số lượng là kiểu số và lớn hơn 0");
        }
    }
}