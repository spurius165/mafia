using System;
namespace Mafia
{
	public enum MessageType
	{
		Undefined = 0,
		Connect = 1,
		Disconnect = 2,
		Turn = 3,
		PassTurn = 4,
		Win = 5,
		Lost = 6,
		Log = 7,
		Error = 8,
	}
}
