using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.InventarioActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class IngresoActivoService
    {
        private readonly HttpClient _httpClient;

        public IngresoActivoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BodegaAPI");
        }

        public async Task<List<GetIdResultUsuarioDTO.UsuarioDTO>> ObtenerUsuario()
        {
            var response = await _httpClient.GetAsync("Usuario");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetIdResultUsuarioDTO.UsuarioDTO>>();
                return result ?? new List<GetIdResultUsuarioDTO.UsuarioDTO>();
            }
            return new List<GetIdResultUsuarioDTO.UsuarioDTO>();
        }

        public async Task<List<GetIdResultInventarioActivoDTO.InventarioActivoDTO>> ObtenerInventarioActivo()
        {
            var response = await _httpClient.GetAsync("InventarioActivo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetIdResultInventarioActivoDTO.InventarioActivoDTO>>();
                return result ?? new List<GetIdResultInventarioActivoDTO.InventarioActivoDTO>();
            }
            return new List<GetIdResultInventarioActivoDTO.InventarioActivoDTO>();
        }

        // Obtener un IngresoActivo por su ID
        public async Task<GetIdResultIngresoActivoDTO> ObtenerIngresoActivoPorId(int id)
        {
            var response = await _httpClient.GetAsync($"IngresoActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultIngresoActivoDTO>();
                return result ?? new GetIdResultIngresoActivoDTO();
            }

            return new GetIdResultIngresoActivoDTO();
        }

        // Crear un nuevo IngresoActivo
        public async Task<int> CrearIngresoActivo(CrearIngresoActivoDTO crearIngresoActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("IngresoActivo", crearIngresoActivoDTO);

            if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				return int.TryParse(result, out var id) ? id : 0;
			}

            return 0;
        }

        // Actualizar un IngresoActivo existente
        public async Task<int> ActualizarIngresoActivo(EditIngresoActivoDTO editIngresoActivoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"IngresoActivo/{editIngresoActivoDTO.Id}", editIngresoActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var id) ? id : 0;
            }

            return 0;
        }

        // Eliminar un IngresoActivo por su ID
        public async Task<int> EliminarIngresoActivo(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"IngresoActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        // Buscar IngresoActivo con parámetros de búsqueda y paginación
        public async Task<SearchResultIngresoActivoDTO> Buscar(SearchQueryIngresoActivoDTO searchQuery)
        {
            var response = await _httpClient.PostAsJsonAsync("IngresoActivo/buscar", searchQuery);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultIngresoActivoDTO>();
                return result ?? new SearchResultIngresoActivoDTO();
            }

            return new SearchResultIngresoActivoDTO();
        }
    }
}
