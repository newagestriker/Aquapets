﻿namespace Aquapets.Shared.Api.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string? message) : base(message)
        {
        }
        public int StatusCode { get; set; }
    }
}
