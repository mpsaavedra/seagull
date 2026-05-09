using System;
using System.Reflection.Metadata;

namespace Seagull;

public class ErrorCodes
{
    public static class Core
    {
        public static readonly Error UnhandledException = new("SG-0001", "Unhandled Exception");
    }

    public static class ApiErrors
    {
        public static readonly Error UnProcessableRequest = new("SG-API-0002", "Api call request is un-processable");
        public static readonly Error RequestDataCouldNotBeNull = new("SG-API-0003", "Request data could not be null");
    }
}
