using System;
using System.ComponentModel.DataAnnotations;

namespace MijemApplication.ViewModels
{
    public class CustomDateValidator : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime lastDate = (DateTime)date;
            return lastDate < DateTime.Now;
        }
    }
}