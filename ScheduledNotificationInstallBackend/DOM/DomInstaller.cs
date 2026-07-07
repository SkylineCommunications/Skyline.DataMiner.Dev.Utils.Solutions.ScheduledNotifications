namespace ScheduledNotificationInstallBackend.DOM
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
	using Skyline.DataMiner.Net.Apps.Modules;
	using Skyline.DataMiner.Net.GenericEnums;
	using Skyline.DataMiner.Net.ManagerStore;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.Net.Sections;
	using Skyline.DataMiner.Utils.DOM.Builders;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;
	using Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models;

	public partial class DomInstaller
	{
		private readonly IConnection _connection;
		private readonly Action<string> _logMethod;

		public DomInstaller(IConnection connection, Action<string> logMethod = null)
		{
			_connection = connection;
			_logMethod = logMethod;
		}

		public void InstallDefaultContent()
		{
			Log("Installation for ScheduledNotification DOM module started...");

			var moduleHelper = new ModuleSettingsHelper(_connection.HandleMessages);
			var moduleExist = moduleHelper.ModuleSettings.Count(ModuleSettingsExposers.ModuleId.Equal(ScheduledNotificationDomMapper.ModuleId)) == 0;
			if (!moduleExist)
			{
				Log("Installing Module Settings...");
			}
			else
			{
				Log("Updating Module Settings...");
			}

			var module = new DomModuleBuilder()
				.WithModuleId(ScheduledNotificationDomMapper.ModuleId)
				.WithInformationEvents(false)
				.WithHistory(true)
				.Build();
			Import(moduleHelper.ModuleSettings, ModuleSettingsExposers.ModuleId.Equal(ScheduledNotificationDomMapper.ModuleId), module);

			if (!moduleExist)
			{
				Log("Installed Scheduled ScheduledNotificationProperties Module Settings");
			}
			else
			{
				Log("Updated Scheduled ScheduledNotificationProperties Module Settings");
			}

			var domHelper = new DomHelper(_connection.HandleMessages, ScheduledNotificationDomMapper.ModuleId);
			InstallScheduledNotification(domHelper);
		}

		private void Log(string message)
		{
			_logMethod?.Invoke($"[ScheduledNotification.Installer.DOM]: {message}");
		}

		private void Import<T>(ICrudHelperComponent<T> crudHelperComponent, FilterElement<T> equalityFilter, T dataType)
			where T : DataType
		{
			bool exists = crudHelperComponent.Read(equalityFilter).Any();

			if (exists)
			{
				crudHelperComponent.Update(dataType);
			}
			else
			{
				crudHelperComponent.Create(dataType);
			}
		}

		private void InstallNotificationSection(DomHelper helper)
		{
			var section = new SectionDefinitionBuilder()
				.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.SectionDefinitionId)
				.WithName("Notification")
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.UserEmail)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.UserEmail))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The user email which will receive notification."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.ItemId)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.ItemId))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The ID of the item for which the notification is sent."))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.NotificationType)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.NotificationType))
					.WithIsOptional(false)
					.WithTooltip("The type of notification.")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>("Instant", 0))
					.AddEnumValue(new GenericEnumEntry<int>("Daily", 1))
					.AddEnumValue(new GenericEnumEntry<int>("Weekly", 2))
					.AddEnumValue(new GenericEnumEntry<int>("Monthly", 3)))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.StartTime)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.StartTime))
					.WithType(typeof(DateTime))
					.WithIsOptional(false)
					.WithTooltip("The start time of the notification."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.OriginSolution)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.OriginSolution))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The Origin Solution of the notification."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.Status)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.Status))
					.WithType(typeof(bool))
					.WithIsOptional(false)
					.WithTooltip("Indicates whether the notification is enabled or disabled."))
				.AddFieldDescriptor(new DomInstanceFieldDescriptorBuilder()
					.WithID(ScheduledNotificationDomMapper.ScheduledNotificationProperties.TemplateId)
					.WithName(nameof(ScheduledNotificationDomMapper.ScheduledNotificationProperties.TemplateId))
					.WithType(typeof(Guid))
					.WithIsOptional(true)
					.WithModule(TemplateDomMapper.ModuleId)
					.WithDefinitions(new[] { TemplateDomMapper.DomDefinitionId })
					.WithTooltip("The template identifier associated with the notification."))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(ScheduledNotificationDomMapper.ScheduledNotificationProperties.SectionDefinitionId.Id), section);
		}

		private void InstallTemplateSection(DomHelper helper)
		{
			var section = new SectionDefinitionBuilder()
				.WithID(TemplateDomMapper.TemplateProperties.SectionDefinitionId)
				.WithName("Template")
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(TemplateDomMapper.TemplateProperties.Name)
					.WithName(nameof(TemplateDomMapper.TemplateProperties.Name))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The name of the template."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(TemplateDomMapper.TemplateProperties.HtmlFilePath)
					.WithName(nameof(TemplateDomMapper.TemplateProperties.HtmlFilePath))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The HTML file path of the template."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(TemplateDomMapper.TemplateProperties.OriginSolution)
					.WithName(nameof(TemplateDomMapper.TemplateProperties.OriginSolution))
					.WithIsOptional(false)
					.WithType(typeof(string))
					.WithTooltip("The origin solution of the template."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(TemplateDomMapper.TemplateProperties.ProcessingScriptName)
					.WithName(nameof(TemplateDomMapper.TemplateProperties.ProcessingScriptName))
					.WithIsOptional(false)
					.WithType(typeof(string))
					.WithTooltip("The processing script name of the template."))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(TemplateDomMapper.TemplateProperties.SectionDefinitionId.Id), section);
		}

		private void InstallScheduledNotificationDefinition(DomHelper helper)
		{
			var definition = new DomDefinitionBuilder()
				.WithID(ScheduledNotificationDomMapper.DomDefinitionId)
				.WithName("ScheduledNotification")
				.AddSectionDefinitionLink(new Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions.SectionDefinitionLink
				{
					SectionDefinitionID = ScheduledNotificationDomMapper.ScheduledNotificationProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.Build();

			Import(helper.DomDefinitions, DomDefinitionExposers.Id.Equal(ScheduledNotificationDomMapper.DomDefinitionId.Id), definition);
		}

		private void InstallTemplateDefinition(DomHelper helper)
		{
			var definition = new DomDefinitionBuilder()
				.WithID(TemplateDomMapper.DomDefinitionId)
				.WithName("Template")
				.AddSectionDefinitionLink(new Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions.SectionDefinitionLink
				{
					SectionDefinitionID = TemplateDomMapper.TemplateProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.Build();

			Import(helper.DomDefinitions, DomDefinitionExposers.Id.Equal(TemplateDomMapper.DomDefinitionId.Id), definition);
		}

		private void InstallScheduledNotification(DomHelper helper)
		{
			InstallNotificationSection(helper);
			InstallTemplateSection(helper);
			InstallScheduledNotificationDefinition(helper);
			InstallTemplateDefinition(helper);
		}
	}
}
