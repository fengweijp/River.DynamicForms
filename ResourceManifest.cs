using Orchard.Environment.Extensions;
using Orchard.UI.Resources;

namespace River.DynamicForms
{
    [OrchardFeature("River.DynamicForms.Elements.ImageFileField")]
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

        
            manifest.DefineScript("RiverDynamicFormsElementsImageFileField").SetUrl("river.dynamicforms.elements.imagefilefield.js").SetDependencies("jQuery");
        }
    }
}
