using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{

	public class RoomViewsModel
	{

		public string RoomName { get; set; }

		private Page _page;

		public RoomViewsModel(Page page)
		{
			_page = page;
		}

		public ObservableCollection<RoomModel> Room { get; set; } = new ObservableCollection<RoomModel>
		{

		};

		public async Task LoadRooms()
		{
			var response = await DataService.GetInstance().GetRoomsAsync();
			var rooms = JsonConvert.DeserializeObject<List<RoomModel>>(response);
			foreach (var room in rooms)
			{
				Room.Add(room);
			}

		}
	}

}
