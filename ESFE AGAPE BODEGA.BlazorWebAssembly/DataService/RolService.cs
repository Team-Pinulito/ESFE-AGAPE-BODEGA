using static ESFE_AGAPE_BODEGA.DTOs.RolDTOs.BuscarRolResultadosDto;
using System.Net.Http.Json;
using ESFE_AGAPE_BODEGA.DTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class RolService
    {
        private readonly HttpClient _httpClient;
        public RolService(IHttpClientFactory httpCli)
        {
            _httpClient = httpCli.CreateClient("BodegaAPI");
        }

        public async Task<BuscarRolResultadosDto> Search(BuscarRolFiltroDto buscarRol)
        {
            var response = await _httpClient.PostAsJsonAsync("Rol/buscar", buscarRol);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<BuscarRolResultadosDto>();
                return result ?? new BuscarRolResultadosDto();
            }
            return new BuscarRolResultadosDto();
        }

        public async Task<ObtenerRolIdDto> ObtenerRol(int id)
        {
            var rol = await _httpClient.GetAsync($"Rol/{id}");

            if (rol.IsSuccessStatusCode) 
            {
                var result = await rol.Content.ReadFromJsonAsync<ObtenerRolIdDto>();
                return result ?? new ObtenerRolIdDto();
            }
            else
                return new ObtenerRolIdDto();
        }
        public async Task<int> CrearRol(CrearRolDto crearRolDto)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("Rol", crearRolDto);

            if (response.IsSuccessStatusCode)
               {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
               }
            return result;
        }
        public async Task<int> ActualizarRol(EditarRolDto editarRolDto)
        {
            int result = 0;
            var response = await _httpClient.PutAsJsonAsync($"Rol/{editarRolDto.Id}", editarRolDto);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }
        public async Task<int> EliminarRol(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"Rol/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }
    }
}
