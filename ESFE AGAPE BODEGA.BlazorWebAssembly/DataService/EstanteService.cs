using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
	public class EstanteService
	{
		private readonly HttpClient _httpClient;
		public EstanteService(IHttpClientFactory httpCli)
		{
			_httpClient = httpCli.CreateClient("BodegaAPI");
		}

		public async Task<List<SearchResultBodegaDTO.BodegaDTO>> ObtenerBodegas()
		{
			var response = await _httpClient.GetAsync("Bodega");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<SearchResultBodegaDTO.BodegaDTO>>();
				return result ?? new List<SearchResultBodegaDTO.BodegaDTO>();
			}
			return new List<SearchResultBodegaDTO.BodegaDTO>();
		}

		public async Task<SearchResultEstanteDTO> Search(SearchQueryEstanteDTO searchQueryEstanteDTO)
		{
			var response = await _httpClient.PostAsJsonAsync("Estante/buscar", searchQueryEstanteDTO);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<SearchResultEstanteDTO>();
				return result ?? new SearchResultEstanteDTO();
			}
			return new SearchResultEstanteDTO();
		}

		public async Task<GetIdResultEstanteDTO> ObtenerEstanteId(int id)
		{
			var rol = await _httpClient.GetAsync($"Estante/{id}");

			if (rol.IsSuccessStatusCode)
			{
				var result = await rol.Content.ReadFromJsonAsync<GetIdResultEstanteDTO>();
				return result ?? new GetIdResultEstanteDTO();
			}
			else
				return new GetIdResultEstanteDTO();
		}
		public async Task<int> CrearEstante(CrearEstanteDTO crearEstanteDTO)
		{
			int result = 0;
			var response = await _httpClient.PostAsJsonAsync("Estante", crearEstanteDTO);

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				if (int.TryParse(responseBody, out result) == false)
					return result = 0;
			}
			return result;
		}
		public async Task<int> ActualizarEstante(EditEstanteDTO editEstanteDTO)
		{
			int result = 0;
			var response = await _httpClient.PutAsJsonAsync($"Estante/{editEstanteDTO.Id}", editEstanteDTO);

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				if (int.TryParse(responseBody, out result) == false)
					return result = 0;
			}
			return result;
		}
		public async Task<int> EliminarEstante(int id)
		{
			int result = 0;
			var response = await _httpClient.DeleteAsync($"Estante/{id}");

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
