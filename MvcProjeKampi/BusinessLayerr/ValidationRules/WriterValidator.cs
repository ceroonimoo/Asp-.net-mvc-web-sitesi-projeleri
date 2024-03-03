using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerr.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer> //bundan önce businessLayera FluentValidation indirdik
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("unvan boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("hakkında boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("lütfen en az 2 karakter girin");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("lütfen 50 karakterden fazla veri girmeyin");
        }
    }
    }
