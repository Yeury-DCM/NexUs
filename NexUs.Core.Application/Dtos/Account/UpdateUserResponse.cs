
namespace NexUs.Core.Application.Dtos.Account
{
    public class UpdateUserResponse
    {
        public string UserId { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
