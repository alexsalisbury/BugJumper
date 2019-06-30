namespace BugJumper.Config
{
    using BugJumper.Models;

    //Original source:
    //https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    public interface IConfigProvider
    {
        ConfigurationData Data { get; }
        ConfigurationData Load();
        ConfigurationData Parse(string data);
        bool Save(ConfigurationData data);
        dynamic ProcessProperties(ConfigurationData parent, dynamic value);
    }
}