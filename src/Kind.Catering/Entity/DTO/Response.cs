using System;

namespace Kind.Catering.Entity.DTO
{
    public sealed class Response<T>
    {
        public bool IsSuccessfully { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }

        public static Response<T> FailedResponse(string error) =>
            new()
            {
                Message = error,
                IsSuccessfully = false,
                Payload = default
            };

        public static Response<T> FailedResponse(Exception ex) =>
            new()
            {
                Message = $"Error: {ex.Message}, StackTrace: {ex.StackTrace}",
                IsSuccessfully = false,
                Payload = default
            };

        public static Response<T> SuccessResponse(T payload, string message = "OK") =>
            new()
            {
                Message = message,
                IsSuccessfully = true,
                Payload = payload
            };
    }
}