namespace BugJumper
{
    using System.ComponentModel;

    public class UrlFormatChangedEventArgs : HandledEventArgs
    {
        public string UriFormat { get; private set; }

        public UrlFormatChangedEventArgs(string format)
        {
            this.UriFormat = format;
        }
    }
}