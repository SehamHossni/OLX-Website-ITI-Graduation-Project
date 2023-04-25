namespace Chatapp.Sharda
{
    public interface IBlazingChatHubClient
    {
        Task UserConnected(UserDto user);
        Task OnlineUsersList(IEnumerable<UserDto> users);
        Task UserIsOnline(int userId);

        Task MessageRecieved(MessageDto messageDto);
    }
}
