﻿using System.Runtime.Serialization;

namespace Poort8.Dataspace.AuthorizationRegistry.Exceptions;
[Serializable]
internal class EnforcerException : Exception
{
    public EnforcerException()
    {
    }

    public EnforcerException(string? message) : base(message)
    {
    }

    public EnforcerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EnforcerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}