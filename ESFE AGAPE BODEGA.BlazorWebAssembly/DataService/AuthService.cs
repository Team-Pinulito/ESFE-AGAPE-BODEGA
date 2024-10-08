﻿using Blazored.SessionStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using Blazored.LocalStorage;
using Timer = System.Timers.Timer;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private Timer _logoutTimer;

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
                await _localStorage.SetItemAsync("id", responseData.id);
                await _localStorage.SetItemAsync("rol", responseData.rol);
                await _localStorage.SetItemAsync("loginTime", DateTime.UtcNow); // Guardar la hora de inicio de sesión
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseData.token);

                StartLogoutTimer(); // Iniciar el temporizador de logout

                return true;
            }

            return false;
        }

        private void StartLogoutTimer()
        {
            _logoutTimer?.Stop(); // Detener cualquier temporizador existente

            // Crear un nuevo temporizador que se dispare después de 8 horas (28800000 ms)
            _logoutTimer = new Timer(28800000);
            _logoutTimer.Elapsed += async (sender, e) => await Logout(); // Llamar al método Logout
            _logoutTimer.AutoReset = false; // No reiniciar automáticamente
            _logoutTimer.Start(); // Iniciar el temporizador
        }

        public async Task Logout()
        {
            await _localStorage.ClearAsync();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _logoutTimer?.Stop(); // Detener el temporizador al hacer logout
        }

        public async Task<int> GetUserId()
        {
            return await _localStorage.GetItemAsync<int>("id");
        }
        public async Task<string> GetUserRole()
        {
            return await _localStorage.GetItemAsync<string>("rol");
        }
        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var loginTime = await _localStorage.GetItemAsync<DateTime>("loginTime");

            // Verificar si el token no está vacío y si han pasado menos de 8 horas desde el inicio de sesión
            return !string.IsNullOrEmpty(token) && (DateTime.UtcNow - loginTime).TotalHours < 8;
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
            public int id { get; set; }
            public string rol { get; set; }
        }
    }
}
