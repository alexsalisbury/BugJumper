﻿namespace BugJumper.Config
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using BugJumper.Models;

    //Original source:
    //https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    public class JsonConfigProvider : IConfigProvider
    {
        public ConfigurationData Load(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                throw new ArgumentNullException("fullPath");
            }

            var json = File.ReadAllText(fullPath);
            return Parse(json);
        }

        public ConfigurationData Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException("json");
            }

            var parsedConfig = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);

            var data = new ConfigurationData(null, parsedConfig, this);
            return data;
        }

        public dynamic ProcessProperties(ConfigurationData parent, dynamic value)
        {
            if (value is string || value is ConfigurationData)
            {
                return value;
            }

            var jObj = value as JObject;
            if (null != jObj)
            {
                var retVal = new ConfigurationData(parent);

                var dict = new Dictionary<string, object>(jObj.Count);
                foreach (var kvp in jObj)
                {
                    dict[kvp.Key] = ProcessProperties(retVal, jObj[kvp.Key]);
                }

                retVal.AddRange(dict);

                return retVal;
            }

            var jVal = value as JValue;
            if (null != jVal)
            {
                return jVal.Value;
            }

            if (value is IEnumerable)
            {
                var retVal = new ConfigurationData(parent);

                var tmpArray = new ArrayList();
                tmpArray.AddRange(value);
                for (int i = 0; i != tmpArray.Count; ++i)
                {
                    retVal[i] = ProcessProperties(parent, tmpArray[i]);
                }

                return retVal;
            }

            return value;
        }
    }
}