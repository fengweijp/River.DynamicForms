using Orchard;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Environment.Extensions;
using River.DynamicForms.Elements;

namespace River.DynamicForms.Bindings
{

    [OrchardFeature("River.DynamicForms.Elements.ImageFileField")]
    public class ImageFileFieldBindings : Component, IBindingProvider {
        public void Describe(BindingDescribeContext context) {
            context.For<ImageFileField>()
                .Binding("Text", (contentItem, field, s) => field.FilePath = s);
        }
    }
}