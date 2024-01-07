using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator()
        {
                RuleFor(x=>x.Title).NotEmpty().WithMessage("Görsel Başlığı boş Geçilemez");
                RuleFor(x=>x.Description).NotEmpty().WithMessage("Görsel Açıklaması boş Geçilemez");
                RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Görsel Yolu boş Geçilemez");
                RuleFor(x=>x.Title).MaximumLength(20).WithMessage("En Fazla 20 Karakter Giriniz");                
                RuleFor(x=>x.Title).MinimumLength(8).WithMessage("En Az 8 Karakter Giriniz");
                RuleFor(x=>x.Description).MinimumLength(20).WithMessage("En Az 20 Karakter Giriniz");
                RuleFor(x => x.Description).MaximumLength(50).WithMessage("En Fazla 50 Karakter Giriniz");
        }
    }
}
