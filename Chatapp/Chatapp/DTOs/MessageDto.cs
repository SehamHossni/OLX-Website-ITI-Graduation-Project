namespace Chatapp
{
    public record MessageDto(int ToUserId, int FromUserId, string Message, DateTime SentOn);
}
