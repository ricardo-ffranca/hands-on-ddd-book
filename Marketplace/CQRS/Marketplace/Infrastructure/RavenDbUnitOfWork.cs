using Marketplace.Framework;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure
{
    public class RavenDbUnitOfWork : IUnitOfWork
    {
        private readonly IAsyncDocumentSession _session;

        public RavenDbUnitOfWork(IAsyncDocumentSession session)
            => _session = session;

        public Task Commit() => _session.SaveChangesAsync();
    }
}
