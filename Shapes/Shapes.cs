using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace River.DynamicForms.Shapes
{
    public class Shapes : IDependency
    {
        public Shapes()
        {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        [Shape]
        public void UploadImageLinkContent(dynamic Display, TextWriter Output, HtmlHelper Html, ContentItem item)
        {
            Output.Write(T("Upload Image"));
        }

        [Shape]
        public void UploadImagePreview(dynamic Display, TextWriter Output, HtmlHelper Html, ContentItem item, string fieldName)
        {
            Output.Write("<img id=\"" + fieldName + "\" style=\"width: 100px; height: 100px; display: none; \" />");
        }
        
    }
}
