using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class SolicitudActivoService
    {
        private readonly HttpClient _httpClient;

        public SolicitudActivoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BodegaAPI");
        }

		public async Task<List<GetIdResultUsuarioDTO.UsuarioDTO>> ObtenerUsuarios()
		{
			var response = await _httpClient.GetAsync("Usuario");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<GetIdResultUsuarioDTO.UsuarioDTO>>();
				return result ?? new List<GetIdResultUsuarioDTO.UsuarioDTO>();
			}
			return new List<GetIdResultUsuarioDTO.UsuarioDTO>();
		}

		//obtener paquetes de activos
		public async Task<List<SearchResultPaqueteActivoDTO.PaqueteActivoDTO>> ObtenerPaquetesActivos()
        {
            var response = await _httpClient.GetAsync("PaqueteActivo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<SearchResultPaqueteActivoDTO.PaqueteActivoDTO>>();
                return result ?? new List<SearchResultPaqueteActivoDTO.PaqueteActivoDTO>();
            }
            return new List<SearchResultPaqueteActivoDTO.PaqueteActivoDTO>();
        }

        public async Task<int> CrearSolicitudActivo(CrearSolicitudActivoDTO crearSolicitudActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("SolicitudActivo", crearSolicitudActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var id) ? id : 0;
            }

            return 0;
        }

        public async Task<GetIdResultSolicitudActivoDTO> ObtenerSolicitudActivoPorId(int id)
        {
            var response = await _httpClient.GetAsync($"SolicitudActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultSolicitudActivoDTO>();
                return result ?? new GetIdResultSolicitudActivoDTO();
            }

            return new GetIdResultSolicitudActivoDTO();
        }

        public async Task<int> ActualizarSolicitudActivo(EditSolicitudActivoDTO editSolicitudActivoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"SolicitudActivo/{editSolicitudActivoDTO.Id}", editSolicitudActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var id) ? id : 0;
            }

            return 0;
        }

        public async Task<int> EliminarSolicitudActivo(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"SolicitudActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<SearchResultSolicitudActivoDTO> Search(SearchQuerySolicitudActivoDTO searchQuery)
        {
            var response = await _httpClient.PostAsJsonAsync("SolicitudActivo/buscar", searchQuery);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultSolicitudActivoDTO>();
                return result ?? new SearchResultSolicitudActivoDTO();
            }

            return new SearchResultSolicitudActivoDTO();
        }
    }
}
