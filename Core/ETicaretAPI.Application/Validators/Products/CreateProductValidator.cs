using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p=>p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını giriniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");
            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen ürünün stok bilgisini giriniz.")
                .Must(s => s >= 0)
                .WithMessage("Lütfen stok bilgisini 0 veya daha büyük giriniz");
            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen ürünün fiyat bilgisini giriniz.")
                .Must(p => p > 0)
                .WithMessage("Lütfen fiyat bilgisini 0'dan büyük giriniz");
        }
    }
}
