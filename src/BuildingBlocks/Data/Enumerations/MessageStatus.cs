using System;

namespace Seagull.Data.Enumerations;

public sealed class MessageStatus(int id, string name) : Enumeration(id, name)
{
    public static MessageStatus Unknown => new MessageStatus(0, "Unknown");
    public static MessageStatus Success => new MessageStatus(1, "Success");
    public static MessageStatus Failure => new MessageStatus(2, "Failure");
    public static MessageStatus Draft => new MessageStatus(3, "Draft");
}
