using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Utils.ScheduledNotifications.Models
{
    [SdmDomMapper]
    public static class TemplateDomMapper
    {
        internal const string ModuleId = "(slc)schedulednotification";
        private static readonly DomDefinitionId TemplateDomDefinitionId = new DomDefinitionId(new Guid("fe30f7ea-6469-4dbf-9d10-04102385dfa3"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => TemplateDomDefinitionId;

        public static class TemplateProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("37e57c94-daf5-4140-807a-d72a23b92ca1"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID Name = new FieldDescriptorID(new Guid("58497ef1-5ffc-4066-ab44-bfb8ed86e31b"));
            public static readonly FieldDescriptorID DashboardFilePath = new FieldDescriptorID(new Guid("b2a3b8e8-a8d1-455b-ab40-461c3d3cc113"));
            public static readonly FieldDescriptorID OriginSolution = new FieldDescriptorID(new Guid("7cc13848-62ea-49e9-8452-2447acd553cb"));
            public static readonly FieldDescriptorID ProcessingScriptName = new FieldDescriptorID(new Guid("0afe7861-077a-4df9-8b71-adc7ebd7c3fd"));
        }
    }
}