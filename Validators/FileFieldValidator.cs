using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.ValidationRules;
using Orchard.Environment.Extensions;
using River.DynamicForms.Elements;
using River.DynamicForms.ValidationRules;
using System.Collections.Generic;

namespace River.DynamicForms.Validators
{
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileFieldValidator : ElementValidator<FileField>
    {
        private readonly IValidationRuleFactory _validationRuleFactory;
        public FileFieldValidator(IValidationRuleFactory validationRuleFactory)
        {
            _validationRuleFactory = validationRuleFactory;
        }

        protected override IEnumerable<IValidationRule> GetValidationRules(FileField element)
        {
            var settings = element.ValidationSettings;

            if (settings.IsRequired == true)
                yield return _validationRuleFactory.Create<Required>(settings.CustomValidationMessage);

            if (settings.AllowOverwrite.HasValue == false || settings.AllowOverwrite == false)
                yield return _validationRuleFactory.Create<FileExists>(settings.CustomValidationMessage);

            if (settings.MaximumSize.HasValue)
                yield return _validationRuleFactory.Create<FileMaxSize>(settings.CustomValidationMessage, x => x.MaxSize = settings.MaximumSize.Value);

            if (!string.IsNullOrWhiteSpace(settings.FileTypes))
                yield return _validationRuleFactory.Create<AcceptedFileTypes>(settings.CustomValidationMessage, x => x.FileTypes = settings.FileTypes);
        }
    }
}
