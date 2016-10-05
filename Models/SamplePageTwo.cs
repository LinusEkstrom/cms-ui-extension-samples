using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Templates.Alloy.Business.EditorDescriptors;
using EPiServer.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UIExtensionSamples.Attributes;
using UIExtensionSamples.EditorDescriptors;

namespace UIExtensionSamples.Models
{
    [ContentType(
        GUID = "D178950C-D20E-4A46-90BD-5338B2424746")]
    public class SamplePageTwo : SamplePageBase, SampleInterface
    {
        #region Suggestion Editors

        /// <summary>
        /// Example of how the SelectOne attribute can be used to get a single selection from
        /// a list of predefined items defined in the specified SelectionFactory.
        /// </summary>
        [SelectOne(SelectionFactoryType = typeof(SampleSelectionFactory))]
        public virtual string Contacts { get; set; }

        /// <summary>
        /// Here we have used the DRY principle to reduce code by defining a specific attribute that extends
        /// SelectOne with a predefined selection factory.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [ContactSelectionAttribute]
        public virtual string CustomCssClass { get; set; }

        /// <summary>
        /// SelectMany works the same as SelectOne but enables the option to select multiple items.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [SelectMany(SelectionFactoryType = typeof(SampleSelectionFactory))]
        public virtual string CustomCssClasses { get; set; }

        /// <summary>
        /// Sample showing how to generate selection from an Enum by creating a custom attribute.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [EnumAttribute(typeof(SampleEnum))]
        public virtual SampleEnum EnumValue { get; set; }

        /// <summary>
        /// This creates an editor that will suggest options for the editor.
        /// The editor has to select one of the predefined choices.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [AutoSuggestSelection(typeof(SampleSelectionQuery))]
        public virtual string SelectionEditor1 { get; set; }

        /// <summary>
        /// This creates an editor that will suggest options for the editor.
        /// The editor can select one of the predefined choices but also enter custom values.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [AutoSuggestSelection(typeof(SampleSelectionQuery), AllowCustomValues = true)]
        public virtual string SelectionEditor2 { get; set; }

        #endregion

        #region List Editors

        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        public virtual IList<Person> Persons { get; set; }

        #endregion

        #region Custom attributes and editor descriptors

        /// <summary>
        /// Prevent editing or hide property when editing unless you are part of specific roles.
        /// </summary>
        [Display(GroupName = TabNames.CustomAttributes)]
        [PropertyEditRestriction(new string[] { "Administrators" })]
        public virtual ContentReference RestrictedToEdit { get; set; }

        /// <summary>
        ///// This property shows how to create a category editor with a custom root node.
        /// </summary>
        [UIHint(CustomCategoryRootEditorDescriptor.CustomCategoryRoot)]
        public virtual CategoryList CustomCategories { get; set; }

        //Additional features that can be shown in the UI:

        //Show ContainerPageUIDescriptor with custom icon and default view.

        //Show SiteMetadataExtender

        //Custom Content View
        //TODO: Create MVC example for a custom view.

        //Drag and drop items into HTML editor

        #endregion
    }
}
