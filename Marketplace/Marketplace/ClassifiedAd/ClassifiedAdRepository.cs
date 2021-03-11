using Marketplace.Domain.ClassifiedAd;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.ClassifiedAd
{
    public class ClassifiedAdRepository : IClassifiedAdRepository
    {
        private readonly IAsyncDocumentSession _session;

        public ClassifiedAdRepository(IAsyncDocumentSession session)
            => _session = session;

        public Task Add(Domain.ClassifiedAd.ClassifiedAd entity)
            => _session.StoreAsync(entity, EntityId(entity.Id));

        public Task<bool> Exists(ClassifiedAdId id)
            => _session.Advanced.ExistsAsync(EntityId(id));

        public Task<Domain.ClassifiedAd.ClassifiedAd> Load(ClassifiedAdId id)
            => _session.LoadAsync<Domain.ClassifiedAd.ClassifiedAd>(EntityId(id));

        private static string EntityId(ClassifiedAdId id)
            => $"ClassifiedAd/{id}";
    }
}
