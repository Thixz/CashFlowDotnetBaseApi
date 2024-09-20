using System.Globalization;
using System.Net.Http.Json;

namespace WebApi.test;
public class CashFlowClassFixture : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public CashFlowClassFixture(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    protected async Task<HttpResponseMessage> DoPost(string requestUri, object request, string token = "", string culture = "en")
    {
        AuthorizeRequest(token);
        ChangesRequesCulture(culture);

        return await _httpClient.PostAsJsonAsync(requestUri, request);
    }

    protected async Task<HttpResponseMessage> DoGet(string requestUri, string token = "", string culture = "en")
    {
        AuthorizeRequest(token);
        ChangesRequesCulture(culture);

        return await _httpClient.GetAsync(requestUri);
    }

    private void AuthorizeRequest(string token)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    private void ChangesRequesCulture(string culture)
    {
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(culture));
    }
}
