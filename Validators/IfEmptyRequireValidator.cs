using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services;
using River.Clarks.Rules;
using River.Clarks.Validators.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River.Clarks.Validators
{
    public class IfEmptyRequireValidator : ElementValidator<TextArea>
    {
        private readonly IValidationRuleFactory _validationRuleFactory;
        public IfEmptyRequireValidator(IValidationRuleFactory validationRuleFactory)
        {
            _validationRuleFactory = validationRuleFactory;
        }

        protected override IEnumerable<IValidationRule> GetValidationRules(TextArea element)
        {
            var settings = element.ValidationSettings;
            var customSettings = element.Data.GetModel<CustomTextAreaValidationSettings>("");

            if (customSettings.IfEmptyRequire != null)
                yield return _validationRuleFactory.Create<IfEmptyRequire>(r => {
                    r.OtherFieldName = customSettings.IfEmptyRequire;
                    r.ErrorMessage = settings.CustomValidationMessage;
                });
        }
    }
    
}
