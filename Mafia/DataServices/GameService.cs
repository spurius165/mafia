using System;
using Newtonsoft.Json;
using Websockets;

namespace Mafia
{
	public class GameService : IGameService
	{
		//private string _url = "ws://10.0.2.2:9000/demo/server.php";
		private string _url = "ws://78.155.207.169:9000/server.php";
		private IWebSocketConnection _webSocket;
		public string _userName;
		public string _userRoom;
		public string _userRoleImg;
		public string _lastKill;

		public static GameService Instance = new GameService();

		public event EventHandler<Message> OnReceive;

		public void GetRoomName(string RoomName)
		{
			_userRoom = RoomName;
		}

		public void GetRoleImg(string RoleImg)
		{
			_userRoleImg = RoleImg;
		}

		public void GetUserName(string UserName)
		{
			_userName = UserName;
		}

		public void GetLastKill(string LastKill)
		{
			_lastKill = LastKill;
		}

		protected GameService()
		{
			_webSocket = WebSocketFactory.Create();
			_webSocket.OnOpened += WebSocket_OnOpened;
			_webSocket.OnClosed += WebSocket_OnClosed;
			_webSocket.OnMessage += WebSocket_OnMessage;
			_webSocket.OnError += WebSocket_OnError;
		}

		public void Connect(string userName)
		{
			//_userName = userName;
			_webSocket.Open(_url);
		}

		public void Disconnect()
		{
			_webSocket.Close();
		}

		//public void PassTurn()
		//{
		//	var msg = new Message { UserType = MessageType.PassTurn, Payload = _userName };
		//	_webSocket.Send(JsonConvert.SerializeObject(msg));
		//}

		public void StartGame() //!!
		{
			var msg = new Message { UserType = "system", UserName = _userName, UserMessage = "start", UserRoom = _userRoom };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		}

		// дневное голосование
		public void DayKill(string userkill) //!!
		{
			var msg = new Message { UserType = "daykill", UserName = _userName, UserMessage = userkill, UserRoom = _userRoom };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		}

		// ночное голосование
		public void NightKill(string nomafiakill) //!!
		{
			var msg = new Message { UserType = "daykill", UserName = _userName, UserMessage = nomafiakill, UserRoom = _userRoom };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		}

		public void NewUser(string Name)
		{
			var msg = new Message { UserType = "newuser", UserName = _userName, UserMessage = Name, UserRoom = _userRoom };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		} 

		public void DelUser(string Name)
		{
			var msg = new Message { UserType = "deluser", UserName = _userName, UserMessage = Name, UserRoom = _userRoom };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		}

		private void WebSocket_OnError(string error)
		{
			OnReceive?.Invoke(this, new Message { UserType = "Error", UserMessage = "error" });
		}

		private void WebSocket_OnMessage(string msg)
		{
			OnReceive?.Invoke(this, JsonConvert.DeserializeObject<Message>(msg));
		}

		private void WebSocket_OnClosed()
		{
			OnReceive?.Invoke(this, new Message { UserType = "Disconnect", UserMessage = string.Empty });
		}

		private void WebSocket_OnOpened()
		{
			var msg = new Message { UserType = "Connect", UserMessage = _userName };
			_webSocket.Send(JsonConvert.SerializeObject(msg));
		}
	}
}
