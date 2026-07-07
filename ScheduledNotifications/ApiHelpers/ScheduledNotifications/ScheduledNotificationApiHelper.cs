namespace Skyline.DataMiner.Utils.ScheduledNotifications.ApiHelpers.ScheduledNotifications
{
	using System;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;

	using ScheduledNotificationDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.ScheduledNotificationDomRepository;

	/// <summary>
	/// Helper class for interacting with ScheduledNotifications in DataMiner.
	/// </summary>
	public class ScheduledNotificationApiHelper
	{
		private readonly IBulkRepository<ScheduledNotification> _ScheduledNotifications;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScheduledNotificationApiHelper"/> class.
		/// </summary>
		/// <param name="connection">The connection to the DataMiner system.</param>
		/// <exception cref="ArgumentNullException">Thrown when the <paramref name="connection"/> is null.</exception>
		public ScheduledNotificationApiHelper(IConnection connection)
		{
			Connection = connection;

			_ScheduledNotifications = new ScheduledNotificationDomRepository(connection);
		}

		/// <summary>
		/// Gets the connection to the DataMiner system.
		/// </summary>
		public IConnection Connection { get; }

		/// <summary>
		/// Gets the repository for managing ScheduledNotifications.
		/// </summary>
		public IBulkRepository<ScheduledNotification> ScheduledNotifications { get { return _ScheduledNotifications; } }
	}
}
