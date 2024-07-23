using RealTimeChatTask.DAL.Interfaces;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;
using RealTimeChatTask.DAL.Repositories;

namespace RealTimeChatTask.DAL.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _appDbContext;
	
	public UnitOfWork(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
		
		ChatRoomRepository = new ChatRoomRepository(appDbContext);
		MessageRepository = new MessageRepository(appDbContext);
	}
	
	public IChatRoomRepository ChatRoomRepository { get; }
	public IMessageRepository MessageRepository { get; }
	
	public async Task SaveAsync()
	{
		await _appDbContext.SaveChangesAsync();
	}
}