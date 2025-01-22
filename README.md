A C# script written in .net 9.0 that invokes the as3 compiler to compile a as3 project without needing intellij.

### How to use?
- Compile the script then run it to get a default parameters.json file.
- Modify the parameters.json and FlexConfig.xml file
- Run the script again to compile the client

### Notes
- Your AS3 Project should have a config.xml file that is a flex-config file, you should replace FlexConfig.xml with that file.
- FlexConfig.xml file gets copied into config.xml when you run the script because for some reason the compiler sets the file to default values after it compiles? 

### Parameters.json file
- JavaPath needs to be a path to a 64bit java.exe file
- SdkPath needs to be a path to the folder that contains the AIR SDK
- JavaExtras are extra arguments for the java process
- ClassPath is the as3 compiler.jar which should be inside of the AIR SDK/lib folder
- ConfigPath should be the path to a copy of the FlexConfig.xml file
- ProjectArguments should be extra arguments that you can get from your project structure page in intellij
