using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs;
using ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class ActivoService
    {
        private readonly HttpClient _httpClient;
        public ActivoService(IHttpClientFactory httpCli)
        {
            _httpClient = httpCli.CreateClient("BodegaAPI");
        }

        public async Task<List<SearchResultEstanteDTO.EstanteDTO>> ObtenerEstante()
        {
            var response = await _httpClient.GetAsync("Estante");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<SearchResultEstanteDTO.EstanteDTO>>();
                return result ?? new List<SearchResultEstanteDTO.EstanteDTO>();
            }
            return new List<SearchResultEstanteDTO.EstanteDTO>();
        }

        public async Task<List<SearchResultTipoActivoDTO.TipoActivoDTO>> ObtenerTipoActivo()
        {
            var response = await _httpClient.GetAsync("TipoActivo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<SearchResultTipoActivoDTO.TipoActivoDTO>>();
                return result ?? new List<SearchResultTipoActivoDTO.TipoActivoDTO>();
            }
            return new List<SearchResultTipoActivoDTO.TipoActivoDTO>();
        }

        public async Task<SearchResultActivoDTO> Search(SearchQueryActivoDTO searchQuery)
        {
            var response = await _httpClient.PostAsJsonAsync("Activo/buscar", searchQuery);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultActivoDTO>();
                return result ?? new SearchResultActivoDTO();
            }
            return new SearchResultActivoDTO();
        }

        public async Task<GetIdResultActivoDTO> ObtenerActivoId(int id)
        {
            var rol = await _httpClient.GetAsync($"Estante/{id}");

            if (rol.IsSuccessStatusCode)
            {
                var result = await rol.Content.ReadFromJsonAsync<GetIdResultActivoDTO>();
                return result ?? new GetIdResultActivoDTO();
            }
            else
                return new GetIdResultActivoDTO();
        }

        public async Task<int> CrearActivo(CrearActivoDTO crearActivo)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("Activo", crearActivo);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<int> ActualizarActivo(EditActivoDTO editActivo)
        {
            int result = 0;
            var response = await _httpClient.PutAsJsonAsync($"Activo/{editActivo.Id}", editActivo);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<int> EliminarActivo(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"Activo/{id}");

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
