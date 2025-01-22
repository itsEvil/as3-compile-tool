using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS3_Compile_Tool;
public static class Log
{
    public static void Debug(string format, params object[] args)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(string.Format(format, args));
    }

    public static void Info(string format, params object[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(string.Format(format, args));
    }

    public static void Error(string format, params object[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(string.Format(format, args));
    }
}
