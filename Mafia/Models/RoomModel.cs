using System;
namespace Mafia
{
	public class RoomModel
	{
		public RoomModel()
		{
		}

		public int IdRoom { get; set; }
		public string Name { get; set; }
		public int Status { get; set; }
		public int players { get; set; }
		public string admin { get; set; }

	}
}
