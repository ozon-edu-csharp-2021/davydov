using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels.RequestModels;
using MerchandiseService.HttpModels.ResponseModels;

namespace MerchandiseService.HttpClient
{
    /// <inheritdoc />
    public class MerchHttpClient : IMerchHttpClient
    {
        /// <summary>
        ///     Создание объекта
        /// </summary>
        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly System.Net.Http.HttpClient _httpClient;
        
        /// <inheritdoc />
        public async Task<IssueMerchResponseModel> V1IssueById(IssueMerchRequestModel request, CancellationToken token)
        {
            using var response = await _httpClient.PutAsync(
                requestUri: $"v1/api/merch/{request.MerchItemId}/issue",
                content: new StringContent(string.Empty),
                token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<IssueMerchResponseModel>(body)
                   ?? throw new ArgumentException(nameof(request));
        }

        /// <inheritdoc />
        public async Task<MerchDistributionInfoResponseModel> V1GetDistributionInfoById(
            MerchDistributionInfoRequestModel request,
            CancellationToken token)
        {
            using var response = await _httpClient.GetAsync(
                $"v1/api/merch/{request.MerchItemId}/distribution",
                token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchDistributionInfoResponseModel>(body)
                   ?? throw new ArgumentException(nameof(request));
        }
    }
}