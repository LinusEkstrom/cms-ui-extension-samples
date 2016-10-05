using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using EPiServer.UI.Report.Reports;
using System;
using System.Collections.Generic;

namespace EPiServer.Cms.Shell.UI.Rest.ContentQuery
{
    [ServiceConfiguration(typeof(IContentQuery))]
    public class MyTaskPlugIn : ContentQueryBase
    {
        private readonly LocalizationService _localizationService;
        private readonly IContentRepository _contentRepository;
        private readonly ExpiredPagesData _expiredPagesData;

        public MyTaskPlugIn(LocalizationService localizationService,
            IContentQueryHelper queryHelper,
            IContentRepository contentRepository,
            ExpiredPagesData expiredPagesData) : base(contentRepository, queryHelper)
        {
            _localizationService = localizationService;
            _contentRepository = contentRepository;
            _expiredPagesData = expiredPagesData;
        }

        public override string Name
        {
            get { return "expiredpages"; }
        }

        public override string DisplayName
        {
            get
            {
                return "Expired pages";
                //Should be localized in a production scenario.
                //return _localizationService.GetString("/add/your/path/to/translation");
            }
        }

        public override IEnumerable<string> PlugInAreas
        {
            //There is currently no static string for this plug-in area.
            get { return new string[] { "editortasks" }; }
        }

        public override int SortOrder
        {
            get { return 105; }
        }

        public override bool VersionSpecific
        {
            //You can configure if the UI should load a specific version or just use normal logic to find the best/latest version.
            get { return false; }
        }

        protected override IEnumerable<IContent> GetContent(ContentQueryParameters parameters)
        {
            int rowCount;

            var expiredPages = _expiredPagesData.GetPages(
                ContentReference.StartPage,
               DateTime.MinValue,
               DateTime.Now,
               ContentLanguage.PreferredCulture.Name,
               false,
               String.Empty,
               50,
               0,
               out rowCount
                );

            var list = new List<IContent>();
            list.AddRange(expiredPages);

            return list;
        }
    }
}