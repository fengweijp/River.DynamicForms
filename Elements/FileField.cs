using Orchard.DynamicForms.Elements;
using Orchard.Environment.Extensions;
using Orchard.Layouts.Helpers;
using River.DynamicForms.Validators.Settings;

namespace River.DynamicForms.Elements
{

    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileField : LabeledFormElement {
        public int FileSize { get; set; }
        public string FilePath
        {
            get { return this.Retrieve(x => x.FilePath); }
            set { this.Store(x => x.FilePath, value); }
        }
        public bool GenerateUnique
        {
            get { return this.Retrieve(x => x.GenerateUnique); }
            set { this.Store(x => x.GenerateUnique, value); }
        }

        public FileFieldValidationSettings ValidationSettings
        {
            get { return Data.GetModel<FileFieldValidationSettings>(""); }
        }
    }
}