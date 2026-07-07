namespace Skyline.DataMiner.Utils.ScheduledNotifications.Repositories
{
	using Skyline.DataMiner.SDM.Middleware;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;
	using Skyline.DataMiner.SDM;

	public static class TemplateDomRepository_Extensions
	{

		public static Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.ScheduledNotifications.Models.Template> WithMiddleware(
			this Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.ScheduledNotifications.Models.Template> repository,
			IMiddlewareMarker<Skyline.DataMiner.Utils.ScheduledNotifications.Models.Template> middleware)
		{
			return new TemplateDomRepository_Middleware(repository, middleware);
		}
	}
}
