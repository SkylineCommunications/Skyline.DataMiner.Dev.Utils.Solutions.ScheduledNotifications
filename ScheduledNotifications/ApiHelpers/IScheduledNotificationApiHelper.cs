namespace Skyline.DataMiner.Utils.ScheduledNotifications.ApiHelpers
{
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;

	public interface IScheduledNotificationApiHelper
	{
		IConnection Connection { get; }

		IBulkRepository<ScheduledNotification> ScheduledNotifications { get; }
	}
}
