using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System.Net.Http.Headers;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly ISessionStorageService _localStorage;

        public AuthTokenHandler(ISessionStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
