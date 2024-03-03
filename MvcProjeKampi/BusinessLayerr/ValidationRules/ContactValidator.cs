using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerr.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu adını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("lütfen en az 3 karakter girin");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("lütfen en az 3 karakter girin");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("lütfen 50 karakterden fazla girmeyin");
        }
    }
}
