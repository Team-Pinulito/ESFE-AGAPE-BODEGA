using ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class KardexActivoService
    {
        private readonly HttpClient _httpClient;

        public KardexActivoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BodegaAPI");
        }

        // Método para obtener todos los KardexActivos con paginación y filtros
        public async Task<SearchResultKardexActivoDTO> ObtenerKardexActivos(SearchQueryKardexActivoDTO searchQueryKardexActivoDTO)
        {
            var response = await _httpClient.GetAsync($"KardexActivo?InventarioActivoId={searchQueryKardexActivoDTO.InventarioActivoId}&FechaMovimiento={searchQueryKardexActivoDTO.FechaMovimiento}&Skip={searchQueryKardexActivoDTO.Skip}&Take={searchQueryKardexActivoDTO.Take}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultKardexActivoDTO>();
                return result ?? new SearchResultKardexActivoDTO();
            }

            return new SearchResultKardexActivoDTO();
        }

        // Método para crear un nuevo KardexActivo
        public async Task<int> CrearKardexActivo(CreateKardexActivoDTO createKardexActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("KardexActivo", createKardexActivoDTO);

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
