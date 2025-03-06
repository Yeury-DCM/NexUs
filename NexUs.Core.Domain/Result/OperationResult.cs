namespace NexUs.Core.Domain.Result
{
    public class OperationResult <T>
    {
        public bool IsSucess { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
