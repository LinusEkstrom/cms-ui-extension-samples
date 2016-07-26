using EPiServer.Shell;
using UIExtensionSamples.Models;

namespace UIExtensionSamples.UIDescriptors
{
    /// <summary>
    /// This descriptor is needed for the AllowedTypes attribute to work for interfaces.
    /// </summary>
    [UIDescriptorRegistration]
    public class SampleInterfaceUIDescriptor : UIDescriptor<SampleInterface>
    {
    }
}