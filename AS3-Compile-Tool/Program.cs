using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AS3_Compile_Tool;
internal class Program {
    public static JsonSerializerOptions JsonOptions;
    private static bool Terminate = false;
    static void Main() {
        JsonOptions = new() {
            WriteIndented = true,
        };

        var paramPath = Path.Combine(Directory.GetCurrentDirectory(), "parameters.json");

        if (!File.Exists(paramPath)) {
            Parameters.CreateDefault(paramPath);
            return;
        }

        var data = File.ReadAllText(paramPath);
        Parameters parameters;
        try
        {
            parameters = JsonSerializer.Deserialize<Parameters>(data, JsonOptions);
        }
        catch(Exception e)
        {
            ExitApplication($"{e.Message}\n\t{e.StackTrace}");
            return;
        }

        if(!parameters.IsValid())
        {
            ExitApplication("Invalid parameter values");
            return;
        }

        BatchBuilder.Build(parameters);
        if (Terminate == true)
            return;

        try
        {
            File.Copy(
                Path.Combine(Directory.GetCurrentDirectory(), "FlexConfig.xml"),
                Path.Combine(Directory.GetCurrentDirectory(), "config.xml")
            );
        } 
        catch(Exception e)
        {
            ExitApplication($"{e.Message}\n\t{e.StackTrace}");
            return;
        }

        Process compiler;
        try
        {
            compiler = Process.Start("script.bat");
        }
        catch(Exception e)
        {
            ExitApplication($"{e.Message}\n\t{e.StackTrace}");
            return;
        }

        Log.Debug("Started compiler Our PID: {0} Compiler PID:{1} Name:{2}", [Environment.ProcessId, compiler.Id, compiler.ProcessName]);

        compiler.WaitForExit();
        ExitApplication($"Compiler exited with code: {compiler.ExitCode}");
        //Just so we dont close our app
        while (!Terminate) {
            Thread.Sleep(8);
        }
    }
    public static void ExitApplication(string msg) {
        Log.Info(msg);
        Thread.Sleep(1_000);
        Log.Info("You can exit this application now");
        Thread.Sleep(5_000);
        Terminate = true;
    }
}


