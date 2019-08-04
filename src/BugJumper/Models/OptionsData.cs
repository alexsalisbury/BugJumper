namespace BugJumper.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class OptionsData
    {
        public OptionsData(ConfigurationData data)
        {
            if (data.ContainsKey("UrlFormat"))
            {
                this.UrlFormat = data["UrlFormat"];
            }

            if (data.ContainsKey("Keywords"))
            {
                this.Keywords = data["Keywords"];
            }
        }

        public string UrlFormat { get; set; }

        public Dictionary<string, Uri> Keywords { get; set; } = new Dictionary<string, Uri>();

        public ConfigurationData GetData()
        {
            dynamic cd = new ConfigurationData();
            if (!string.IsNullOrWhiteSpace(this.UrlFormat))
            {
                cd.UrlFormat = this.UrlFormat;
            }

            if ((this.Keywords?.Count ?? 0) > 0)
            {
                cd.Keywords = this.Keywords;
            }

            return cd;
        }
    }
}
