using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.CustomValidations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class EnsureListElementsAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;
        public EnsureListElementsAttribute(int min = 0, int max = int.MaxValue)
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object value)
        {
            if (!(value is IList list)) return false;

            return list.Count >= _min || list.Count <= _max;
        }
    }
}
