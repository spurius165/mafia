using System;
namespace Mafia
{
	public interface IGameService
	{
		event EventHandler<Message> OnReceive;
		void Connect(string userName);
		void Disconnect();
	}
}
