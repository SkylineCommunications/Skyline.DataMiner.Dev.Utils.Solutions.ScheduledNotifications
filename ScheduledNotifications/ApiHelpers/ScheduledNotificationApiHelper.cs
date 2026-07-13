namespace Skyline.DataMiner.Utils.ScheduledNotifications.ApiHelpers
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;

	using ScheduledNotificationDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.ScheduledNotificationDomRepository;
	using ScheduledNotificationExposers = Exposers.ScheduledNotificationExposers;
	using TemplateDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.TemplateDomRepository;
	using TemplateExposers = Exposers.TemplateExposers;

	/// <summary>
	/// Helper class for interacting with ScheduledNotifications in DataMiner.
	/// </summary>
	public class ScheduledNotificationApiHelper
	{
		private readonly IBulkRepository<ScheduledNotification> _scheduledNotifications;
		private readonly IBulkRepository<Template> _templates;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScheduledNotificationApiHelper"/> class.
		/// </summary>
		/// <param name="connection">The connection to the DataMiner system.</param>
		/// <exception cref="ArgumentNullException">Thrown when the <paramref name="connection"/> is null.</exception>
		public ScheduledNotificationApiHelper(IConnection connection)
		{
			Connection = connection;

			_scheduledNotifications = new ScheduledNotificationDomRepository(connection);
			_templates = new TemplateDomRepository(connection);
		}

		/// <summary>
		/// Gets the connection to the DataMiner system.
		/// </summary>
		public IConnection Connection { get; }

		/// <summary>
		/// Gets the repository for managing ScheduledNotifications.
		/// </summary>
		public IBulkRepository<ScheduledNotification> ScheduledNotifications { get { return _scheduledNotifications; } }

		/// <summary>
		/// Gets the repository for managing Templates.
		/// </summary>
		public IBulkRepository<Template> Templates { get { return _templates; } }

		/// <summary>
		/// Retrieves a template by its name.
		/// </summary>
		/// <param name="templateName">The name of the template to retrieve. The comparison is case-insensitive.</param>
		/// <returns>The matching <see cref="Template"/>, or <c>null</c> if no template with the specified name exists.</returns>
		public Template GetTemplateByName(string templateName)
		{
			var template = _templates.Read(TemplateExposers.Name.Equal(templateName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();

			return template;
		}

		/// <summary>
		/// Checks whether a scheduled notification already exists with the same user email, item ID, notification type, origin solution, and template ID.
		/// </summary>
		/// <param name="scheduledNotification">The scheduled notification to check for duplicates.</param>
		/// <returns><c>true</c> if a matching notification exists; otherwise, <c>false</c>.</returns>
		public bool NotificationExists(ScheduledNotification scheduledNotification)
		{
			var notification = _scheduledNotifications.Read(ScheduledNotificationExposers.UserEmail.Equal(scheduledNotification.UserEmail, StringComparison.InvariantCultureIgnoreCase)
				.AND(ScheduledNotificationExposers.ItemId.Equal(scheduledNotification.ItemId, StringComparison.InvariantCultureIgnoreCase))
				.AND(ScheduledNotificationExposers.NotificationType.Equal(scheduledNotification.NotificationType))
				.AND(ScheduledNotificationExposers.OriginSolution.Equal(scheduledNotification.OriginSolution, StringComparison.InvariantCultureIgnoreCase))
				.AND(ScheduledNotificationExposers.TemplateId.Equal(scheduledNotification.TemplateId)))
				.SingleOrDefault();

			return notification != null;
		}
	}
}
