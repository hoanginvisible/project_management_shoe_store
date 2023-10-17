using FluentValidation;
using Service.Handlers.ProductDetails.Command;

namespace QuanLyCuaHangBanGiay.Commons.Validators.ProductDetails
{
    public class UpdateProductDetailCommandValidator : AbstractValidator<UpdateProductDetailCommand>
    {
        public UpdateProductDetailCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("không tồn tại");
            RuleFor(x => x.IdMaterial).NotEmpty().WithMessage("Chất liệu không để trống");
            RuleFor(x => x.IdCategory).NotEmpty().WithMessage("gzfgssdgsd");
            RuleFor(x => x.IdProduct).NotEmpty().WithMessage("hsdhs");
            RuleFor(x => x.IdBrand).NotEmpty().WithMessage("gdf");
            RuleFor(x => x.IdColor).NotEmpty().WithMessage("gd");
            RuleFor(x => x.IdSize).NotEmpty().WithMessage("dgfd");
            RuleFor(x => x.Price).NotNull().WithMessage("df");
            RuleFor(x => x.Quantity).NotNull().WithMessage("dgf");
        }
    }
}

