using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ValidationAttributes
{
    public class NotAllowEmptyStringAttribute : ValidationAttribute
    {
        public NotAllowEmptyStringAttribute()
        {
            
        }

        public override bool IsValid(object? value)
        {
            if(value == null || value.ToString() == "")
            {
                return false;
            }
            return base.IsValid(value);
        }
    }
}
