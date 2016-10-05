using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UIExtensionSamples.EditorDescriptors;
using UIExtensionSamples.PropertySettings;

namespace UIExtensionSamples.Models
{
    [ContentType(
        GUID = "D178950C-D20E-4A46-90BD-5338B2424747")]
    public class SamplePageOne : SamplePageBase, SampleInterface
    {
        #region BuiltInContentReferences

        //Samples of content references with different hints to be able to pick different content.
        //For Commerce, there is a bunch of more hints to be able to pick different catalog content.

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Block)]
        public virtual ContentReference BlockReference { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.BlockFolder)]//BlockFolder and MediaFolder gives the same result since the folder structure is the same
        public virtual ContentReference Folder { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Image)]//Anything that implements IContentImage
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Video)]//Anything that implements IContentVideo
        public virtual ContentReference Video { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference MediaFileOfAnyType { get; set; }

        #endregion

        #region Url

        // Using a URL property as a reference is useful if you want to be able to store 
        // additional information in the URL, for instance [mediapath]?size=medium

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.MediaFile)]
        public virtual Url FileAsUrl { get; set; }

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.Image)]//Anything that implements IContentImage.
        public virtual Url ImageAsUrl { get; set; }

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.Video)]//Anything that implements IContentVideo.
        public virtual Url VideoAsUrl { get; set; }

        #endregion

        
        #region CustomReferences

        //You can build your own content reference editors.

        [Display(GroupName = TabNames.CustomReferences)]
        [UIHint(SampleBlockReferenceEditorDescriptor.SampleBlockHint)]
        public virtual ContentReference SampleBlock { get; set; }

        #endregion

        #region AllowedTypes

        /// <summary>
        /// You can use the AllowedTypes attribute to restrict what an editor can add to a content area.
        /// This sample shows a content area only allowing SampleBlock.
        /// </summary>
        [Display(GroupName = TabNames.AllowedTypes)]
        [CultureSpecific]
        [AllowedTypes(new Type[] { typeof(SampleBlock) })]
        public virtual ContentArea RestrictedToSampleBlock { get; set; }

        /// <summary>
        /// You can use also configure the AllowedTypes attribute to reject content of certain types.
        /// This sample shows a content area restricted for all blocks except TeaserBlock.
        /// </summary>
        [Display(GroupName = TabNames.AllowedTypes)]
        [CultureSpecific]
        [AllowedTypes(new Type[] { typeof(BlockData) }, new Type[] { typeof(SampleBlock) })]
        public virtual ContentArea RestrictedToAllBlocksButSampleBlock { get; set; }


        /// <summary>
        /// You can add restrictions for base types.
        /// </summary>
        [Display(GroupName = TabNames.AllowedTypes)]
        [AllowedTypes(new Type[] { typeof(SamplePageBase) })]
        public virtual ContentArea RestrictedToSampleBaseClass { get; set; }

        [Display(GroupName = TabNames.AllowedTypes)]
        [AllowedTypes(new Type[] { typeof(PageData) })]
        public virtual IList<ContentReference> PageList { get; set; }


        /// <summary>
        /// You can add restrictions for interfaces as well, but to be able to do this
        /// you need to add an UIDescriptor for the interface since Episerver does not do this automatically.
        /// See SampleInterfaceUIDescriptor.
        /// </summary> 
        [Display(GroupName = TabNames.AllowedTypes)]
        [AllowedTypes(new Type[] { typeof(SampleInterface) })]
        public virtual ContentArea RestrictedToSampleInterface { get; set; }

        #endregion

        #region Property Settings

        [CultureSpecific]
        [PropertySettings(typeof(SimpleTinyMCESettings))]
        public virtual XhtmlString MainBody { get; set; }

        #endregion
    }
}
