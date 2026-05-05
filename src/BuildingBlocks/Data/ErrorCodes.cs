using System;
using System.Data;

namespace Seagull.Data;

public class ErrorCodes : Seagull.ErrorCodes
{
    public static class Data
    {
        public static readonly Error DataException = new Error("SG-DT-00001", "Unhandled data exception");
    }
}
