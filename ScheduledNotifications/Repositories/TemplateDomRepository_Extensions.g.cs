namespace Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Repositories
{
	using Skyline.DataMiner.SDM.Middleware;
	using Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models;
	using Skyline.DataMiner.SDM;

	public static class TemplateDomRepository_Extensions
	{

		public static Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models.Template> WithMiddleware(
			this Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models.Template> repository,
			IMiddlewareMarker<Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
		{
			return new TemplateDomRepository_Middleware(repository, middleware);
		}
	}
}
