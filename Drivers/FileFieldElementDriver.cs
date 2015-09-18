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
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileFieldElementDriver : FormsElementDriver<FileField>
    {
        private readonly ITokenizer _tokenizer;

        public FileFieldElementDriver(IFormManager formManager, ITokenizer tokenizer) : base(formManager) {
            _tokenizer = tokenizer;
        }

        protected override EditorResult OnBuildEditor(FileField element, ElementEditorContext context) {
            var autoLabelEditor = BuildForm(context, "AutoLabel");
            var fileFieldEditor = BuildForm(context, "FileField");
            var fileFieldValidation = BuildForm(context, "FileFieldValidation", "Validation:10");

            return Editor(context, autoLabelEditor, fileFieldEditor, fileFieldValidation);
        }

        protected override void DescribeForm(DescribeContext context) {
            context.Form("FileField", factory => {
                var shape = (dynamic)factory;
                var form = shape.Fieldset(
                    Id: "FileField",
                     _GenerateUnique: shape.Checkbox(
                        Id: "GenerateUnique",
                        Name: "GenerateUnique",
                        Title: "Unique Filename",
                        Value: "true",
                        Description: T("Check to generate unique filename on upload")),
                    _FilePath: shape.Textbox(
                        Id: "FilePath",
                        Name: "FilePath",
                        Title: "FilePath",
                        Classes: new[] { "text", "medium", "tokenized" },
                        Description: T("The path for the uploaded file (e.g. c:\\media\\).")));
                return form;
            });

            context.Form("FileFieldValidation", factory => {
                var shape = (dynamic)factory;
                var form = shape.Fieldset(
                    Id: "FileFieldValidation",
                    _IsRequired: shape.Checkbox(
                        Id: "IsRequired",
                        Name: "IsRequired",
                        Title: "Required",
                        Value: "true",
                        Description: T("Check to make the file field a required field.")),
                    _MaximumSize: shape.Textbox(
                        Id: "MaximumSize",
                        Name: "MaximumSize",
                        Title: "Maximum Size",
                        Classes: new[] { "text", "medium" },
                        Description: T("The maximum file size (MB) allowed.")),
                    _FileTypes: shape.Textbox(
                        Id: "FileTypes",
                        Name: "FileTypes",
                        Title: "File Types",
                        Classes: new[] { "text", "large" },
                        Description: T("Comma separated list of allowed file extensions")),
                    _AllowOverwrite: shape.Checkbox(
                        Id: "AllowOverwrite",
                        Name: "AllowOverwrite",
                        Title: "Overwrite Allowed",
                        Value: "true",
                        Description: T("Check to allow the file field to overwrite existing files.")),
                    _CustomValidationMessage: shape.Textbox(
                        Id: "CustomValidationMessage",
                        Name: "CustomValidationMessage",
                        Title: "Custom Validation Message",
                        Classes: new[] { "text", "large", "tokenized" },
                        Description: T("Optionally provide a custom validation message.")),
                    _ShowValidationMessage: shape.Checkbox(
                        Id: "ShowValidationMessage",
                        Name: "ShowValidationMessage",
                        Title: "Show Validation Message",
                        Value: "true",
                        Description: T("Autogenerate a validation message when a validation error occurs for the current field. Alternatively, to control the placement of the validation message you can use the ValidationMessage element instead.")));

                return form;
            });
        }

        protected override void OnDisplaying(FileField element, ElementDisplayContext context)
        {
            context.ElementShape.ProcessedName = _tokenizer.Replace(element.Name, context.GetTokenData());
            context.ElementShape.ProcessedLabel = _tokenizer.Replace(element.Label, context.GetTokenData());
            context.ElementShape.ProcessedValue = _tokenizer.Replace(element.RuntimeValue, context.GetTokenData());
        }

    }
}