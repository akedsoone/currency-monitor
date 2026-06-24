using CurrencyMonitor.Api.Constants;
using CurrencyMonitor.Api.Interfaces;
using CurrencyMonitor.Api.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace CurrencyMonitor.Api.Services
{
    public class BanckApiService : IApiService
    {
        public async Task<DepartmentAmountsResponse> GetAmountsAsync()
        {
            return await ApiConstants.CurrencyApiLink
                .SetQueryParams(new
                {
                    extclientid = 1,
                    extsystemid = "current"
                })
                .WithBasicAuth(ApiConstants.Login, ApiConstants.Password)
                .GetJsonAsync<DepartmentAmountsResponse>();
        }
    }
}