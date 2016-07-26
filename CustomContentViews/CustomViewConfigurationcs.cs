using System.Web;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using UIExtensionSamples.Models;

namespace UIExtensionSamples.CustomContentViews
{
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class SampleView : ViewConfiguration<SamplePageOne>
    {
        public SampleView()
        {
            Key = "sampleView";
            Name = "Sample View";
            Description = "A very basic custom view for content.";
            //We set the controller type to IFrameController to get an custom page in an iframe.
            ControllerType = "epi-cms/widget/IFrameController";
            //This sample shows a Web Forms page. You can use MVC as well but there is
            //some helper functionality like resolving the content item passed to the page
            //that there is currently no built in support for MVC.
            ViewType = VirtualPathUtility.ToAbsolute("~/cms-ui-extension-samples/CustomContentViews/CustomContentView.aspx");
            IconClass = "epi-iconForms";
        }
    }
}