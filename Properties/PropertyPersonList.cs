using EPiServer.Core;
using EPiServer.PlugIn;
using Newtonsoft.Json;
using UIExtensionSamples.Models;

namespace UIExtensionSamples.Properties
{
    [PropertyDefinitionTypePlugIn]
    public class PropertyPersonList : PropertyList<Person>
    {
        protected override Person ParseItem(string value)
        {
            return JsonConvert.DeserializeObject<Person>(value);
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }
    }
}