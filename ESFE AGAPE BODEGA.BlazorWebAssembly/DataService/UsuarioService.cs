using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService(IHttpClientFactory httpCli)
        {
            _httpClient = httpCli.CreateClient("BodegaAPI");
        }

        public async Task<List<BuscarRolResultadosDto.RolDto>> ObtenerRoles()
        {
            var response = await _httpClient.GetAsync("Rol");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BuscarRolResultadosDto.RolDto>>();
                return result ?? new List<BuscarRolResultadosDto.RolDto>();
            }
            return new List<BuscarRolResultadosDto.RolDto>();
        }

        public async Task<GetIdResultUsuarioDTO> Search(SearchQueryUsuarioDTO searchQueryUsuario)
        {
            var response = await _httpClient.PostAsJsonAsync("usuario/buscar", searchQueryUsuario);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultUsuarioDTO>();
                return result ?? new GetIdResultUsuarioDTO();
            }
            return new GetIdResultUsuarioDTO();
        }

        public async Task<GetIdResultUsuarioDTO.UsuarioDTO> ObtenerUsuario(int id)
        {
            var rol = await _httpClient.GetAsync($"usuario/buscar/{id}");

            if (rol.IsSuccessStatusCode)
            {
                var result = await rol.Content.ReadFromJsonAsync<GetIdResultUsuarioDTO.UsuarioDTO>();
                return result ?? new GetIdResultUsuarioDTO.UsuarioDTO();
            }
            else
                return new GetIdResultUsuarioDTO.UsuarioDTO();
        }
        public async Task<int> CrearUsuario(CrearUsuarioDTO crearUsuario)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("usuario", crearUsuario);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }
        public async Task<int> ActualizarUsuario(EditUsuarioDTO editUsuario)
        {
            int result = 0;
            var response = await _httpClient.PutAsJsonAsync($"usuario/{editUsuario.Id}", editUsuario);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }
        public async Task<int> EliminarUsuario(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"usuario/{id}");

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
