using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class BodegaService
    {
        private readonly HttpClient _httpClient;
        public BodegaService(IHttpClientFactory httpCli)
        {
            _httpClient = httpCli.CreateClient("BodegaAPI");
        }

        public async Task<SearchResultBodegaDTO> Search(SearchQueryBodegaDTO searchQuery)
        {
            var response = await _httpClient.PostAsJsonAsync("Bodega", searchQuery);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultBodegaDTO>();
                return result ?? new SearchResultBodegaDTO();
            }
            return new SearchResultBodegaDTO();
        }

        public async Task<ObtenerRolIdDto> ObtenerRol(int id)
        {
            var rol = await _httpClient.GetAsync($"Bodega/{id}");

            if (rol.IsSuccessStatusCode)
            {
                var result = await rol.Content.ReadFromJsonAsync<ObtenerRolIdDto>();
                return result ?? new ObtenerRolIdDto();
            }
            else
                return new ObtenerRolIdDto();
        }
    }
}
