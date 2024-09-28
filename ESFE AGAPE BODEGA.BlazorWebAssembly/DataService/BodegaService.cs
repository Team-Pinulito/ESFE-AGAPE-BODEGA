using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
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
            var response = await _httpClient.PostAsJsonAsync("Bodega/buscar", searchQuery);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultBodegaDTO>();
                return result ?? new SearchResultBodegaDTO();
            }
            return new SearchResultBodegaDTO();
        }

        public async Task<GetIdResultBodegaDTO> ObtenerBodega(int id)
        {
            var rol = await _httpClient.GetAsync($"Bodega/{id}");

            if (rol.IsSuccessStatusCode)
            {
                var result = await rol.Content.ReadFromJsonAsync<GetIdResultBodegaDTO>();
                return result ?? new GetIdResultBodegaDTO();
            }
            else
                return new GetIdResultBodegaDTO();
        }

        public async Task<int> CrearBodega(CrearBodegaDTO crearBodega)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("Bodega", crearBodega);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<int> ActualizarBodega(EditBodegaDTO editBodega)
        {
            int result = 0;
            var response = await _httpClient.PutAsJsonAsync($"Bodega/{editBodega.Id}", editBodega);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<int> EliminarBodega(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"Bodega/{id}");

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
