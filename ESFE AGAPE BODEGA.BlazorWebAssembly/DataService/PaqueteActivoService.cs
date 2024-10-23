using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class PaqueteActivoService
    {
		private readonly HttpClient _httpClient;

		public PaqueteActivoService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("BodegaAPI");
		}

		public async Task<string> ObtenerCorrelativo()
		{
			try
			{
				// Obtener todos los correlativos de ambos servicios
				var ingresosResponse = await _httpClient.GetAsync("IngresoActivo");
				var paquetesResponse = await _httpClient.GetAsync("PaqueteActivo");

				int maxNumero = 0;

				if (ingresosResponse.IsSuccessStatusCode)
				{
					var ingresos = await ingresosResponse.Content.ReadFromJsonAsync<List<GetIdResultIngresoActivoDTO>>();
					if (ingresos != null)
					{
						foreach (var ingreso in ingresos)
						{
							if (string.IsNullOrEmpty(ingreso.Correlativo)) continue;
							string[] partes = ingreso.Correlativo.Split('-');
							if (partes.Length == 2 && int.TryParse(partes[1], out int numero))
							{
								maxNumero = Math.Max(maxNumero, numero);
							}
						}
					}
				}

				if (paquetesResponse.IsSuccessStatusCode)
				{
					var paquetes = await paquetesResponse.Content.ReadFromJsonAsync<List<GetIdResultPaqueteActivoDTO>>();
					if (paquetes != null)
					{
						foreach (var paquete in paquetes)
						{
							if (string.IsNullOrEmpty(paquete.Correlativo)) continue;
							string[] partes = paquete.Correlativo.Split('-');
							if (partes.Length == 2 && int.TryParse(partes[1], out int numero))
							{
								maxNumero = Math.Max(maxNumero, numero);
							}
						}
					}
				}

				// Incrementar el número más alto encontrado
				return $"ESFE-{(maxNumero + 1):000}";
			}
			catch
			{
				return "ESFE-001";
			}
		}

		public async Task<List<SearchResultActivoDTO.ActivoDTO>> ObtenerActivos()
        {
            var response = await _httpClient.GetAsync("Activo");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<SearchResultActivoDTO.ActivoDTO>>();
                return result ?? new List<SearchResultActivoDTO.ActivoDTO>();
            }
            return new List<SearchResultActivoDTO.ActivoDTO>();
        }

        public async Task<int> CrearPaqueteActivo(CrearPaqueteActivoDTO crearPaqueteActivoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("PaqueteActivo", crearPaqueteActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var id) ? id : 0;
            }

            return 0;
        }

        public async Task<GetIdResultPaqueteActivoDTO> ObtenerPaqueteActivoPorId(int id)
        {
            var response = await _httpClient.GetAsync($"PaqueteActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultPaqueteActivoDTO>();
                return result ?? new GetIdResultPaqueteActivoDTO();
            }

            return new GetIdResultPaqueteActivoDTO();
        }

        public async Task<int> ActualizarPaqueteActivo(EditPaqueteActivoDTO editPaqueteActivoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"PaqueteActivo/{editPaqueteActivoDTO.Id}", editPaqueteActivoDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return int.TryParse(result, out var id) ? id : 0;
            }

            return 0;
        }

        public async Task<int> EliminarPaqueteActivo(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"PaqueteActivo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        public async Task<SearchResultPaqueteActivoDTO> Search(SearchQueryPaqueteActivoDTO searchQuery)
        {
            var response = await _httpClient.PostAsJsonAsync("PaqueteActivo/buscar", searchQuery);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultPaqueteActivoDTO>();
                return result ?? new SearchResultPaqueteActivoDTO();
            }

            return new SearchResultPaqueteActivoDTO();
        }
    }
}
