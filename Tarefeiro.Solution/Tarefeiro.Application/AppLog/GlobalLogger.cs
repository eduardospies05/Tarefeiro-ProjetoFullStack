using System;
using Serilog;

namespace Tarefeiro.Application.AppLog;

public static class GlobalLogger
{
    public static void LogException(Exception ex)
    {
        string msg = ex.Message;

        LogToDebug(msg);
        LogToConsole(msg);
        LogToFile(msg);
    }

    public static void LogToDebug(string msg)
        => Log.Debug(msg);
    
    public static void LogToConsole(string msg)
        => Log.Warning(msg);

    public static void LogToFile(string msg)
        => Log.Information(msg);
}
