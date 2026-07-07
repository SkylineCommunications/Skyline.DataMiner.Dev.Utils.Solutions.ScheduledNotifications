using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Repositories
{
	using Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.SDM;

	using SLDataGateway.API.Types.Querying;

	using System;
	using System.Collections.Generic;

	internal sealed partial class TemplateDomRepository_Middleware : Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template>
	{
		private readonly Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> _inner;
		private readonly IMiddlewareMarker<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> _middleware;

		public TemplateDomRepository_Middleware(Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> inner, IMiddlewareMarker<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
		{
			_inner = inner ?? throw new ArgumentNullException(nameof(inner));
			_middleware = middleware;
		}

		public IEnumerable<IPagedResult<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template>> ReadPaged(FilterElement<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> filter)
		{
			if (_middleware is IPageableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnReadPaged(filter, _inner.ReadPaged);
			}
			else
			{
				return _inner.ReadPaged(filter);
			}
		}

		public IEnumerable<IPagedResult<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template>> ReadPaged(IQuery<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> query)
		{
			if (_middleware is IPageableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnReadPaged(query, _inner.ReadPaged);
			}
			else
			{
				return _inner.ReadPaged(query);
			}
		}

		public IEnumerable<IPagedResult<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template>> ReadPaged(FilterElement<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> filter, int pageSize)
		{
			if (_middleware is IPageableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnReadPaged(filter, pageSize, _inner.ReadPaged);
			}
			else
			{
				return _inner.ReadPaged(filter, pageSize);
			}
		}

		public IEnumerable<IPagedResult<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template>> ReadPaged(IQuery<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> query, int pageSize)
		{
			if (_middleware is IPageableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnReadPaged(query, pageSize, _inner.ReadPaged);
			}
			else
			{
				return _inner.ReadPaged(query, pageSize);
			}
		}

		public IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> Read(FilterElement<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> filter)
		{
			if (_middleware is IReadableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnRead(filter, _inner.Read);
			}
			else
			{
				return _inner.Read(filter);
			}
		}

		public IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> Read(IQuery<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> query)
		{
			if (_middleware is IReadableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnRead(query, _inner.Read);
			}
			else
			{
				return _inner.Read(query);
			}
		}

		public long Count(FilterElement<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> filter)
		{
			if (_middleware is ICountableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnCount(filter, _inner.Count);
			}
			else
			{
				return _inner.Count(filter);
			}
		}

		public long Count(IQuery<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> query)
		{
			if (_middleware is ICountableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnCount(query, _inner.Count);
			}
			else
			{
				return _inner.Count(query);
			}
		}

		public IReadOnlyCollection<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> Create(IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> oToCreate)
		{
			if (_middleware is IBulkCreatableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnCreate(oToCreate, _inner.Create);
			}
			else
			{
				return _inner.Create(oToCreate);
			}
		}

		public Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template Create(Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template oToCreate)
		{
			if (_middleware is ICreatableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnCreate(oToCreate, _inner.Create);
			}
			else
			{
				return _inner.Create(oToCreate);
			}
		}

		public IReadOnlyCollection<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> Update(IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> oToUpdate)
		{
			if (_middleware is IBulkUpdatableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnUpdate(oToUpdate, _inner.Update);
			}
			else
			{
				return _inner.Update(oToUpdate);
			}
		}

		public Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template Update(Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template oToUpdate)
		{
			if (_middleware is IUpdatableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				return middleware.OnUpdate(oToUpdate, _inner.Update);
			}
			else
			{
				return _inner.Update(oToUpdate);
			}
		}

		public void Delete(IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> oToDelete)
		{
			if (_middleware is IBulkDeletableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				middleware.OnDelete(oToDelete, _inner.Delete);
			}
			else
			{
				_inner.Delete(oToDelete);
			}
		}

		public void Delete(Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template oToDelete)
		{
			if (_middleware is IDeletableMiddleware<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> middleware)
			{
				middleware.OnDelete(oToDelete, _inner.Delete);
			}
			else
			{
				_inner.Delete(oToDelete);
			}
		}
		public System.Collections.Generic.IReadOnlyCollection<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> CreateOrUpdate(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models.Template> oToCreateOrUpdate)
		{
			return _inner.CreateOrUpdate(oToCreateOrUpdate);
		}

	}
}
