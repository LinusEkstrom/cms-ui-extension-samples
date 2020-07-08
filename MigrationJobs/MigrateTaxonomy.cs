// This is a base that can be used when migrating taxonomy settings in the form of two List<ContentReference> where you want to migrate
// from one property to another given a mapping table of target pages. The code has solution specific parts that needs to be changed to compile and run.
//using EPiServer;
//using EPiServer.Core;
//using EPiServer.DataAccess;
//using EPiServer.PlugIn;
//using EPiServer.Scheduler;
//using EPiServer.Security;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Episervercom.Site.Infrastructure.Migrations
//{
//    [ScheduledPlugIn(DisplayName = "Migrate Features To Capabilities Scheduled Job")]
//    public class MigrateFeaturesToCapabilitiesScheduledJob : ScheduledJobBase
//    {
//        private bool _stopSignaled;

//        private Dictionary<int, int> _mappingTable;
//        private readonly IContentRepository _contentRepository;

//        public MigrateFeaturesToCapabilitiesScheduledJob(IContentRepository contentRepository)
//        {
//            _contentRepository = contentRepository;
//            IsStoppable = true;

//            _mappingTable = new Dictionary<int, int>
//            {
//                { 931, 14672},
//                { 939, 14523},
//                { 7588, 14545},
//                { 10094, 14756},
//                { 5627, 14551},
//                { 9659, 14555},
//                { 926, 14559},
//                { 10259, 14149},
//                { 9669, 14516},
//                { 1415, 14504},
//                { 928, 14790},
//                { 1453, 14377},
//                { 1459, 14470},
//                { 940, 14762},
//                { 5626, 14766},
//                { 6763, 14772},
//                { 5338, 14759}
//            };
//        }

//        /// <summary>
//        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
//        /// </summary>
//        public override void Stop()
//        {
//            _stopSignaled = true;
//        }

//        /// <summary>
//        /// Called when a scheduled job executes
//        /// </summary>
//        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
//        public override string Execute()
//        {
//            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
//            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));
//            var failedPages = new List<int>();

//            var allPages = _contentRepository.GetDescendents(ContentReference.StartPage);

//            int i = 0;
//            int amountChanged = 0;

//            foreach (var pageReference in allPages)
//            {
//                PageData page;
//                _contentRepository.TryGet<PageData>(pageReference, out page);

//                if (page is TeasableContentPageBase teasableContentPageBase && teasableContentPageBase.Features != null && teasableContentPageBase.Features.Any())
//                {
//                    i++;
//                    var clone = page.CreateWritableClone() as TeasableContentPageBase;
//                    bool changed = false;

//                    foreach (var feature in teasableContentPageBase.Features)
//                    {
//                        if (!_mappingTable.ContainsKey(feature.ID))
//                        {
//                            continue;
//                        }

//                        var newValue = _mappingTable[feature.ID];
//                        if (clone.Capabilities == null)
//                        {
//                            clone.Capabilities = new List<ContentReference>();
//                        }
//                        var capabilityReference = new ContentReference(newValue);
//                        if (!clone.Capabilities.Contains(capabilityReference))
//                        {
//                            clone.Capabilities.Add(capabilityReference);
//                            changed = true;
//                        }
//                    }
//                    if (changed)
//                    {
//                        amountChanged++;

//                        try
//                        {
//                            _contentRepository.Save(clone, SaveAction.Patch, AccessLevel.NoAccess);
//                        }
//                        catch (Exception)
//                        {
//                            failedPages.Add(clone.ContentLink.ID);
//                        }
//                    }
//                }

//                if (i % 10 == 0)
//                {
//                    OnStatusChanged($"On page nr {i}. Changed {amountChanged} pages.");
//                }
//            }

//            //For long running jobs periodically check if stop is signaled and if so stop execution
//            if (_stopSignaled)
//            {
//                return "Stop of job was called";
//            }

//            var failedPagesString = string.Join(",", failedPages);

//            return $"Migrated {amountChanged} pages of {i} that has a value for features. Failed pages {failedPagesString}";
//        }
//    }
//}
