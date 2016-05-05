using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.WindowsAzure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Stores
{
    /// <summary>
    ///     Retreive <see cref="Scope"/> information from a Azure Storage Table.
    /// </summary>
    /// <seealso cref="IdentityServer3.Core.Services.IScopeStore" />
    public class ScopeStore : IScopeStore
    {
        private readonly CloudTable _table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScopeStore"/> class.
        /// </summary>
        /// <param name="table">
        ///     The Azure Storage Table that stores <see cref="Scope"/>Scopres.
        /// </param>
        public ScopeStore(CloudTable table)
        {
            _table = table;
        }

        /// <summary>
        ///     Gets all scopes.
        /// </summary>
        /// <param name="scopeNames">
        ///     List of scopes to return if they exist.
        /// </param>
        /// <returns>
        ///     List of scopes in the store that exist in <paramref name="scopeNames"/>.
        /// </returns>
        public Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException("todo");
        }

        /// <summary>
        ///     Gets all defined scopes.
        /// </summary>
        /// <param name="publicOnly">
        ///     if set to <c>true</c> only public scopes 
        ///     (<see cref="Scope.ShowInDiscoveryDocument"/>) are returned.
        /// </param>
        /// <returns>
        ///     List of all defined scopes.
        /// </returns>
        public Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            throw new NotImplementedException("todo");
        }
    }
}