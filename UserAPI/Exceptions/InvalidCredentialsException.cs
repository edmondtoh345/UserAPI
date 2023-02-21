﻿namespace UserAPI.Exceptions
{
    public class InvalidCredentialsException: Exception
    {
        public InvalidCredentialsException() { }
        public InvalidCredentialsException(string message) : base(message) { }
    }
}
