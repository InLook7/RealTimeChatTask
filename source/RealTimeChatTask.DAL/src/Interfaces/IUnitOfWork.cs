using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Interfaces;

public interface IUnitOfWork
{
	IChatRoomRepository ChatRoomRepository { get; }
	IMessageRepository MessageRepository { get; }
	
	Task SaveAsync();
}