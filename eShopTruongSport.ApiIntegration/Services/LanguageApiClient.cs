using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {

        public LanguageApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory, httpContextAccessor , configuration  )
        {
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVm>>>("api/languages");
        }
    }
}
