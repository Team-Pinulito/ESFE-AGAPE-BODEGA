using Blazored.SessionStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using Blazored.LocalStorage;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(IHttpClientFactory httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient.CreateClient("BodegaAPI");
            _localStorage = localStorage;
        }

        public async Task<bool> Login(LoginUsuarioDTO loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/authenticate", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
                await _localStorage.SetItemAsync("authToken", responseData.token);
                await _localStorage.SetItemAsync("nombre", responseData.nombre);
                await _localStorage.SetItemAsync("apellido", responseData.apellido);
                await _localStorage.SetItemAsync("rol", responseData.rol);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseData.token);

                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            await _localStorage.ClearAsync();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> GetUserRole()
        {
            return await _localStorage.GetItemAsync<string>("rol");
        }
        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }

        public async Task<ClaimsPrincipal> GetUserClaims()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
            {
                return new ClaimsPrincipal(new ClaimsIdentity());
            } 

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            return new ClaimsPrincipal(identity);
        }

        public class LoginResponseDTO
        {
            public string token { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string rol { get; set; }
        }
    }
}
