using System.Text.Json;

namespace AS3_Compile_Tool;
public class Parameters {
    public string JavaPath { get; set; }
    public string SdkPath { get; set; }
    public string JavaExtras { get; set; }
    public string ClassPath { get; set; }
    public string ConfigPath { get; set; }
    public string ProjectArguments { get; set; }
    public static void CreateDefault(string path)
    {
        Log.Error("Parameters.json not found.");
        var json = JsonSerializer.Serialize(new Parameters()
        {
            JavaPath = DefaultJava64Path,
            JavaExtras = DefaultJavaExtras,
            ClassPath = DefaultClassPathValue,
            ConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "FlexConfig.xml"),
            SdkPath = DefaultSDKPath,
            ProjectArguments = DefaultProjectArguments
        }, Program.JsonOptions);

        try
        {

            File.WriteAllText(path, json);

        }
        catch (Exception e)
        {
            Program.ExitApplication($"{e.Message}\n\t{e.StackTrace}");
            return;
        }


        Program.ExitApplication("Created default parameters.json file, modify it before running script again.");
    }

    public bool IsValid() {
        return 
            !string.IsNullOrEmpty(JavaPath) && 
            !string.IsNullOrEmpty(SdkPath) && 
            !string.IsNullOrEmpty(ClassPath) && 
            !string.IsNullOrEmpty(ConfigPath);
    }

    private const string DefaultJava64Path = "C:\\Program Files\\JetBrains\\IntelliJ IDEA 2019.1.4\\jre64\\bin\\java.exe";
    private const string DefaultSDKPath = "C:\\Users\\micha\\Documents\\GitHub\\FPFlash-Client\\sdk";
    private const string DefaultJavaExtras = "-Dfile.encoding=UTF-8 -Djava.awt.headless=true -Duser.language=en -Duser.region=en -Xmx512m";
    private const string DefaultClassPathValue = "C:\\Users\\micha\\Documents\\GitHub\\FPFlash-Client\\sdk\\lib\\compiler.jar";
    private const string DefaultProjectArguments = "-default-size 800 600 -default-frame-rate 120 -default-background-color #000000 -swf-version 32 -dump-config config.xml -optimize=true -use-direct-blit=true -keep-as3-metadata+=Inject -keep-as3-metadata+=Embed -keep-as3-metadata+=PostConstruct -keep-as3-metadata+=ArrayElementType";
}
