namespace Skyline.DataMiner.Utils.ScheduledNotifications.Repositories
{
	using Skyline.DataMiner.SDM.Middleware;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;
	using Skyline.DataMiner.SDM;

	public static class ScheduledNotificationDomRepository_Extensions
	{

		public static Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.ScheduledNotifications.Models.ScheduledNotification> WithMiddleware(
			this Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.ScheduledNotifications.Models.ScheduledNotification> repository,
			IMiddlewareMarker<Skyline.DataMiner.Utils.ScheduledNotifications.Models.ScheduledNotification> middleware)
		{
			return new ScheduledNotificationDomRepository_Middleware(repository, middleware);
		}
	}
}