using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River.DynamicForms.Rules
{
    public class IfEmptyRequire : ValidationRule
    {
        public string OtherFieldName { get; set; }
        public override void Validate(ValidateInputContext context)
        {
            if (string.IsNullOrWhiteSpace(context.AttemptedValue))
            {
                //check OtherFieldName has value
                var value = context.Values[OtherFieldName];
                if (string.IsNullOrWhiteSpace(OtherFieldName) || string.IsNullOrWhiteSpace(value))
                {
                    var message = GetValidationMessage(context);
                    context.ModelState.AddModelError(context.FieldName, message.Text);
                }
            }
        }

        public override void RegisterClientAttributes(RegisterClientValidationAttributesContext context)
        {
        }

        private LocalizedString GetValidationMessage(ValidationContext context)
        {
            return T(Tokenize(ErrorMessage.WithDefault(String.Format("{0} or {1} are required.", context.FieldName, OtherFieldName)), context));
        }
    }
}
