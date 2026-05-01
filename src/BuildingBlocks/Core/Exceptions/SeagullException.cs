using System;

namespace Seagull.Exceptions;

public sealed class SeagullException : Exception
{
    public SeagullException(string msg) : base(msg)
    {
    }
}
