using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AS3_Compile_Tool;
public static class BatchBuilder {
    public static void Build(Parameters @params)
    {
        StringBuilder sb = new();
        sb.Append('"');
        sb.Append(@params.JavaPath);
        sb.Append('"');
        sb.Append(' ');
        sb.Append(DApplication);
        sb.Append('"');
        sb.Append(@params.SdkPath);
        sb.Append('"');
        sb.Append(' ');
        sb.Append(@params.JavaExtras);
        sb.Append(' ');
        sb.Append(ClassPath);
        sb.Append(' ');
        sb.Append('"');
        sb.Append(@params.ClassPath);
        sb.Append('"');
        sb.Append(' ');
        sb.Append(MXMLC);
        sb.Append(' ');
        sb.Append(LoadConfig);
        sb.Append('"');
        sb.Append(@params.ConfigPath);
        sb.Append('"');
        sb.Append(' ');
        sb.Append(@params.ProjectArguments);
        sb.Append(' ');

        var arguments = sb.ToString();

        File.WriteAllText("script.bat", arguments);
    }

    private const string DApplication = "-Dapplication.home=";
    private const string ClassPath = "-classpath";
    private const string MXMLC = "com.adobe.flash.compiler.clients.MXMLC";
    private const string LoadConfig = "-load-config=";
}
