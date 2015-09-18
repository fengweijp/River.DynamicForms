using Orchard.DynamicForms.Services.Models;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River.DynamicForms.Validators.Settings
{
    [OrchardFeature("River.DynamicForms.Elements.FileField")]
    public class FileFieldValidationSettings : ValidationSettingsBase
    {
        public bool? IsRequired { get; set; }
        public bool? AllowOverwrite { get; set; }
        public int? MaximumSize { get; set; }
        public string FileTypes { get; set; }
    }
}
