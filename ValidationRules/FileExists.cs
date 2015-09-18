using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using System;
using System.IO;

namespace River.DynamicForms.ValidationRules
{
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileExists : ValidationRule
    {

        public override void Validate(ValidateInputContext context)
        {
            if (string.IsNullOrWhiteSpace(context.AttemptedValue))
                return;

            if (File.Exists(context.AttemptedValue))
            {
                var message = GetValidationMessage(context);
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }
        }

        private LocalizedString GetValidationMessage(ValidationContext context)
        {
            return T(Tokenize(ErrorMessage.WithDefault(String.Format("This file already exists.", context.FieldName)), context));
        }
    }
}