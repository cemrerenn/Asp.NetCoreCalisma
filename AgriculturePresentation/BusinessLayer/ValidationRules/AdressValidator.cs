using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdressValidator:AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.Desctiption1).NotEmpty().WithMessage("Açıkama 1 Boş Geçilemez");
            RuleFor(x => x.Desctiption2).NotEmpty().WithMessage("Açıkama 2 Boş Geçilemez");
            RuleFor(x => x.Desctiption3).NotEmpty().WithMessage("Açıkama 3 Boş Geçilemez");
            RuleFor(x => x.Desctiption4).NotEmpty().WithMessage("Açıkama 4 Boş Geçilemez");
            RuleFor(x => x.Mapinfo).NotEmpty().WithMessage("Harita Bilgisi Boş Geçilemez");
            RuleFor(x => x.Desctiption1).MaximumLength(25).WithMessage("Açıklama En Fazla 25 Karakter Olmalıdır.");
        }
    }
}
