using System;
using System.Threading.Tasks;
using Anotar.NLog;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.WindowsAzure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Services
{
    public class UserService : IUserService
    {
        private readonly CloudTable _table;

        public UserService(CloudTable table)
        {
            _table = table;
        }

        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(PreAuthenticateAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(AuthenticateLocalAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(AuthenticateExternalAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(PostAuthenticateAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task SignOutAsync(SignOutContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(SignOutAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(GetProfileDataAsync)}(...)");
            throw new NotImplementedException("todo");
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            LogTo.Error($"todo: {nameof(UserService)}.{nameof(IsActiveAsync)}(...)");
            throw new NotImplementedException("todo");
        }
    }
}