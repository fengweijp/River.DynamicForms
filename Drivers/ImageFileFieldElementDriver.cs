using Orchard.Environment.Extensions;
using Orchard.Forms.Services;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Tokens;
using River.DynamicForms.Elements;
using DescribeContext = Orchard.Forms.Services.DescribeContext;

namespace River.DynamicForms.Drivers
{
    [OrchardFeature("River.DynamicForms.Elements.ImageFileField")]
    public class ImageFileFieldElementDriver : FormsElementDriver<ImageFileField>
    {
        private readonly ITokenizer _tokenizer;

        public ImageFileFieldElementDriver(IFormManager formManager, ITokenizer tokenizer) : base(formManager) {
            _tokenizer = tokenizer;
        }

        protected override void OnDisplaying(ImageFileField element, ElementDisplayContext context)
        {
            context.ElementShape.ProcessedName = _tokenizer.Replace(element.Name, context.GetTokenData());
            context.ElementShape.ProcessedLabel = _tokenizer.Replace(element.Label, context.GetTokenData());
            context.ElementShape.ProcessedValue = _tokenizer.Replace(element.RuntimeValue, context.GetTokenData());
        }

    }
}