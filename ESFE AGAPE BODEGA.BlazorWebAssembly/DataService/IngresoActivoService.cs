using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
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

        // Obtener todos los IngresoActivo
        public async Task<List<GetIdResultIngresoActivoDTO>> ObtenerTodos()
        {
            var response = await _httpClient.GetAsync("IngresoActivo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetIdResultIngresoActivoDTO>>();
                return result ?? new List<GetIdResultIngresoActivoDTO>();
            }

            return new List<GetIdResultIngresoActivoDTO>();
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
            var response = await _httpClient.DeleteAsync($"IngresoActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var parsedId) ? parsedId : 0;
            }

            return 0;
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
