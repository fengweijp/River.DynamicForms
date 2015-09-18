using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using System;
using System.IO;
using System.Linq;

namespace River.DynamicForms.ValidationRules
{
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class AcceptedFileTypes : ValidationRule
    {

        public string FileTypes { get; set; }


        public override void Validate(ValidateInputContext context)
        {
            if (string.IsNullOrWhiteSpace(context.AttemptedValue))
                return;

            var fileTypes = FileTypes.Split(',');

            var fileExtension = Path.GetExtension(context.AttemptedValue);

            if(!fileTypes.Any(x => x.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
            {
                var message = GetValidationMessage(context);
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }
        }

        public override void RegisterClientAttributes(RegisterClientValidationAttributesContext context)
        {
        }

        private LocalizedString GetValidationMessage(ValidationContext context)
        {
            return T(Tokenize(ErrorMessage.WithDefault(String.Format("{0} must be one of the following file types: {1}.", context.FieldName, FileTypes.Replace(",", ", "))), context));
        }
    }
}
