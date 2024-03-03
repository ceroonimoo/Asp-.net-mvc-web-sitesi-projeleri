using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerr.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("lütfen en az 3 karakter girin");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("lütfen en az 3 karakter girin");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("lütfen 100 karakterden fazla girmeyin");
        }
    }
}
