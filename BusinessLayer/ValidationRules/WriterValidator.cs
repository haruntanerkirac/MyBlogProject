﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı alanı boş bırakılamaz!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail adresi alanı boş bırakılamaz!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifre alanı boş bırakılamaz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız!");
            RuleFor(x=>x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız!");

        }
    }
}
