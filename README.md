# PlaceAppApi
Pre-Requirements: 
    The following tools should be installed on your development machine:

    An IDE (e.g. Visual Studio) that supports .NET 6.0+ development.

    Node v12 or v14

    Yarn v1.20+ (not v2) 1 or npm v6+ (already installed with Node)

    1 Yarn v2 works differently and is not supported. ↩


-- Run APPLICATION -- 
Install the ABP CLI:
    dotnet tool install -g Volo.Abp.Cli
Right click to the .DbMigrator project and select Set as StartUp Project, Hit F5 (or Ctrl+F5) to run the application. It will have an output like shown below:
![image](https://user-images.githubusercontent.com/62060849/182127661-d3367a52-6d48-4860-8457-4b5a3deec3a6.png)
Before starting the application, run abp install-libs command in your Web directory to restore the client-side libraries. This will populate the libs folder.
Ensure that the .Web project is the startup project. Run the application which will open the login page in your browser:

If you dont get it, you click this link below:
https://docs.abp.io/en/abp/latest/Getting-Started-Setup-Environment?UI=MVC&DB=Mongo&Tiered=No
  
