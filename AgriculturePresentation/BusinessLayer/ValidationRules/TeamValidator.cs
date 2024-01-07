using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x=>x.PersonName).NotEmpty().WithMessage("Takım arkadaşı ismi boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("En fazla 50 karakter girilebilir.");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("En az 5 karakter girilebilir.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girilebilir.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 5 karakter girilebilir.");
        }

        public ValidationResult Validate(Image ımage)
        {
            throw new NotImplementedException();
        }
    }
}
