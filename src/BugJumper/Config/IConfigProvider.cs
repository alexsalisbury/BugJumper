namespace BugJumper.Config
{
    using BugJumper.Models;

    //Original source:
    //https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    public interface IConfigProvider
    {
        ConfigurationData Load(string fullPath);
        ConfigurationData Parse(string data);
        dynamic ProcessProperties(ConfigurationData parent, dynamic value);
    }
}