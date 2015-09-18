using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using System;

namespace River.DynamicForms.ValidationRules
{
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileMaxSize : ValidationRule
    {

        public int MaxSize { get; set; }

        public override void Validate(ValidateInputContext context)
        {
            //if no file uploaded
            if (string.IsNullOrWhiteSpace(context.Values[context.FieldName]))
                return;

            var fileSize = context.Values[context.FieldName + ":Size"];

            int contentLength;
            if (!int.TryParse(fileSize, out contentLength))
            {
                var message = GetValidationMessage(context, "{0} is an invalid file.");
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }

            var contentLengthMB = contentLength / 1048576;

            if (contentLengthMB > MaxSize)
            {
                var message = GetValidationMessage(context, "{0} cannot be more than {1} MB.");
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }
        }

        private LocalizedString GetValidationMessage(ValidationContext context, string message)
        {
            return T(Tokenize(ErrorMessage.WithDefault(String.Format(message, context.FieldName, MaxSize)), context));
        }
    }
}