using ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class TipoActivoService
    {
        private readonly HttpClient _httpClient;

        public TipoActivoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BodegaAPI");
        }

        // Obtener todos los tipos de activos
        public async Task<List<GetIdResultTipoActivoDTO>> ObtenerTodos()
        {
            var response = await _httpClient.GetAsync("TipoActivo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetIdResultTipoActivoDTO>>();
                return result ?? new List<GetIdResultTipoActivoDTO>();
            }
            return new List<GetIdResultTipoActivoDTO>();
        }

        // Buscar tipos de activos con paginación y filtros
        public async Task<SearchResultTipoActivoDTO> Buscar(SearchQueryTipoActivoDTO searchQueryTipoActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("TipoActivo/buscar", searchQueryTipoActivoDTO);
            if (response.IsSuccessStatusCode)
            {
                // Cambiamos para que devuelva SearchResultTipoActivoDTO en lugar de SearchQueryTipoActivoDTO
                var result = await response.Content.ReadFromJsonAsync<SearchResultTipoActivoDTO>();
                Console.WriteLine($"Total de datos: {result?.Data?.Count ?? 0}"); // Verificar cuántos datos se están obteniendo
                return result ?? new SearchResultTipoActivoDTO();
            }
            return new SearchResultTipoActivoDTO();
        }

        // Obtener un tipo de activo por su ID
        public async Task<GetIdResultTipoActivoDTO> ObtenerPorId(int id)
        {
            var response = await _httpClient.GetAsync($"TipoActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultTipoActivoDTO>();
                return result ?? new GetIdResultTipoActivoDTO();
            }
            return new GetIdResultTipoActivoDTO();
        }

        // Crear un nuevo tipo de activo
        public async Task<int> Crear(CrearTipoActivoDTO crearTipoActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("TipoActivo", crearTipoActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out int result))
                {
                    return result;
                }
            }

            return 0;
        }

        // Actualizar un tipo de activo existente
        public async Task<int> Actualizar(EditTipoActivoDTO editTipoActivoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"TipoActivo/{editTipoActivoDTO.Id}", editTipoActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out int result))
                {
                    return result;
                }
            }

            return 0;
        }

        // Eliminar un tipo de activo
        public async Task<int> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"TipoActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out int result))
                {
                    return result;
                }
            }
            return 0;
        }
    }
}
