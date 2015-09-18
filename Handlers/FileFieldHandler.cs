using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services;
using River.DynamicForms.Elements;

namespace River.DynamicForms.Handlers
{
    public class FileFieldHandler : FormElementEventHandlerBase
    {

        public override void GetElementValue(FormElement element, ReadElementValuesContext context)
        {
            var fileField = element as FileField;

            if (fileField == null)
                return;

            context.Output[fileField.Name] = fileField.PostedValue;
        }
    }
}