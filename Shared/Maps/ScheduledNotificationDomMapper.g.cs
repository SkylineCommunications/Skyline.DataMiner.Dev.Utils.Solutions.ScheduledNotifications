using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Utils.ScheduledNotifications.Models
{
    [SdmDomMapper]
    public static class ScheduledNotificationDomMapper
    {
        internal const string ModuleId = "(slc)schedulednotification";
        private static readonly DomDefinitionId ScheduledNotificationDomDefinitionId = new DomDefinitionId(new Guid("c40f14f0-3104-4cc8-a377-3e827598e26f"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => ScheduledNotificationDomDefinitionId;

        public static class ScheduledNotificationProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("1cf2c672-f6cc-4095-b110-d0a34838c6cd"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID UserEmail = new FieldDescriptorID(new Guid("81ff15ee-d774-4e93-9c58-c5994244c6a6"));
            public static readonly FieldDescriptorID ItemId = new FieldDescriptorID(new Guid("d53670bf-4bd0-4396-b388-447c5b78db81"));
            public static readonly FieldDescriptorID NotificationType = new FieldDescriptorID(new Guid("7fa81806-665a-4c1a-8cd9-5341a7c3b86e"));
            public static readonly FieldDescriptorID OriginSolution = new FieldDescriptorID(new Guid("cb6e2f81-9a43-4d57-8c10-3ef7b54a9d26"));
            public static readonly FieldDescriptorID Status = new FieldDescriptorID(new Guid("91f3b8d5-2e74-4a0f-b9c3-7d1658ae42fb"));
            public static readonly FieldDescriptorID TemplateId = new FieldDescriptorID(new Guid("e28c4a7f-15d3-4b6c-84e2-f9137da5bc60"));
        }
    }
}