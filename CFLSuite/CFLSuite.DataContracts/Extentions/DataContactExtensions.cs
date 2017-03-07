using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts
{
    public static class DataContactExtensions
    {
        public static void ValidateModel(this object model)
        {
            var vc = new ValidationContext(model);

            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, vc, validationResults, true))
            {
                if (validationResults.Count > 0)
                {
                    throw new Exception(validationResults[0].ErrorMessage);
                }
            }
        }
    }
}
