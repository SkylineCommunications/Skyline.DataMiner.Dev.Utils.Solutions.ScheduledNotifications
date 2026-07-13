namespace Skyline.DataMiner.Utils.ScheduledNotifications.ApiHelpers
{
	using System;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;

	using ScheduledNotificationDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.ScheduledNotificationDomRepository;
	using TemplateDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.TemplateDomRepository;

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

		public IBulkRepository<Template> Templates { get { return _templates; } }
	}
}
