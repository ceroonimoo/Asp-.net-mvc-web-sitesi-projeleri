using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerr.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category> //bundan önce businessLayera FluentValidation indirdik
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("kategori adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("açıklama boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("lütfen açıklamayı en az 3 karakter girin");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("lütfen 20 karakterden fazla veri girmeyin");
        }
    }
}
