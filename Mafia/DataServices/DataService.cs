using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mafia
{
	public class DataService
	{
		private static DataService _instance = new DataService();
		private HttpClient _client = new HttpClient();
		//private string _baseUrl = "http://10.0.2.2/mafia/api";
		private string _baseUrl = "http://78.155.207.169/api";

		public static DataService GetInstance()
		{
			return _instance;
		}


		public async Task<string> GetRoomsAsync()
		{
			try
			{
				return await _client.GetStringAsync($"{_baseUrl}/rooms.php");
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}


		// загрузка живых людей
		public async Task<string> GetPeopleAsync(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/getlistofaliveday.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

			public async Task<string> GetKolMafAsync()
			{
				try
				{
					var json = "{\"UserRoom\":\"" + GameService.Instance._userRoom + "\"} ";
					var response = await _client.PostAsync($"{_baseUrl}/getkolmaf.php", new StringContent(json));
					return await response.Content.ReadAsStringAsync();
				}
				catch (Exception e)
				{
					return e.Message;
			}
			}

		public async Task<string> GetAdmin(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/whoadmin.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
		//
		// загрузка мирных жителей
		public async Task<string> GetNoMafiaAsync(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/getlistofmir.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
		//


		public async Task<string> GetLogAsync(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/getlogs.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}


		public async Task<string> GetRole(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/getrole.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;

			}
		}

		//

		public async Task<string> NewRoomsAsync(string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/newroom.php", new StringContent(json));
				return await response.Content.ReadAsStringAsync();

			}
			catch (Exception e)
			{
				return e.Message;
			}

		}

		//

	}
}
