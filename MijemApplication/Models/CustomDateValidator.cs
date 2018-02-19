using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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