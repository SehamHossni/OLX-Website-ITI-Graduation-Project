namespace Chatapp.Sharda
{
    public interface IBlazingChatHubServer
    {
        Task SetUserOnline(UserDto user);
    }
}
