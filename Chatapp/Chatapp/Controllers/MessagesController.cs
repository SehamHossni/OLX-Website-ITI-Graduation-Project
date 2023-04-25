using Chatapp.Data;
using Chatapp.Data.Entities;
using Chatapp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Chatapp.Sharda;
using Microsoft.AspNetCore.Authorization;

namespace Chatapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : BaseController
    {
        private readonly ChatContext _chatContext;
        private readonly IHubContext<BlazingChatHub, IBlazingChatHubClient> _hubContext;

        public MessagesController(ChatContext chatContext, IHubContext<BlazingChatHub, IBlazingChatHubClient> hubContext)
        {
            _chatContext = chatContext;
            _hubContext = hubContext;
        }

        // /api/messages
        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> SendMessage(MessageSendDto messageDto, CancellationToken cancellationToken)
        {
            if (messageDto.ToUserId <= 0 || string.IsNullOrWhiteSpace(messageDto.Message))
                return BadRequest();

            var message = new Message
            {
                FromId = base.UserId,
                ToId = messageDto.ToUserId,
                Content = messageDto.Message,
                SentOn = DateTime.Now
            };
            await _chatContext.Messages.AddAsync(message, cancellationToken);
            if(await _chatContext.SaveChangesAsync(cancellationToken) > 0)
            {
                var responseMessageDto = new MessageDto(message.ToId, message.FromId, message.Content, message.SentOn);
                await _hubContext.Clients.User(messageDto.ToUserId.ToString())
                            .MessageRecieved(responseMessageDto);
                return Ok();
            }
            else
            {
                return StatusCode(500, "Unable to send message");
            }
        }

        [HttpGet("{otherUserId:int}")]
        [Authorize]
        public async Task<IEnumerable<MessageDto>> GetMessages(int otherUserId, CancellationToken cancellationToken)
        {
            var messages = await _chatContext.Messages
                            .AsNoTracking()
                            .Where(m =>
                                (m.FromId == otherUserId && m.ToId == UserId)
                                || (m.ToId == otherUserId && m.FromId == UserId)
                            )
                            .Select(m=> new MessageDto(m.ToId, m.FromId, m.Content, m.SentOn))
                            .ToListAsync(cancellationToken);

            return messages;
        }
    }
}
