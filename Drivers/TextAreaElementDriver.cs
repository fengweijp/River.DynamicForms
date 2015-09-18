using System.Collections.Generic;
using Orchard.DynamicForms.Elements;
using Orchard.Forms.Services;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Tokens;
using DescribeContext = Orchard.Forms.Services.DescribeContext;

namespace River.Clarks.Drivers
{
    public class TextAreaElementDriver : FormsElementDriver<TextArea>
    {
        private readonly ITokenizer _tokenizer;
        public TextAreaElementDriver(IFormManager formManager, ITokenizer tokenizer) : base(formManager)
        {
            _tokenizer = tokenizer;
        }

        protected override EditorResult OnBuildEditor(TextArea element, ElementEditorContext context)
        {
            var textAreaValidation = BuildForm(context, "CustomTextAreaValidation", "Validation:15");
            return Editor(context, textAreaValidation);
        }

        protected override void DescribeForm(DescribeContext context)
        {
           context.Form("CustomTextAreaValidation", factory => {
                var shape = (dynamic)factory;
               var form = shape.Fieldset(
                   Id: "CustomTextAreaValidation",
                   _IfEmptyRequire: shape.Textbox(
                       Id: "IfEmptyRequire",
                       Name: "IfEmptyRequire",
                       Title: "If Empty, Require",
                       Classes: new[] { "text", "medium", "tokenized" },
                       Description: T("The name of the field that is required if this field is empty.")));
                   
                return form;
            });
        }

        protected override void OnDisplaying(TextArea element, ElementDisplayContext context)
        {
            context.ElementShape.ProcessedName = _tokenizer.Replace(element.Name, context.GetTokenData());
            context.ElementShape.ProcessedLabel = _tokenizer.Replace(element.Label, context.GetTokenData());
            context.ElementShape.ProcessedValue = _tokenizer.Replace(element.RuntimeValue, context.GetTokenData());
        }
    }
}