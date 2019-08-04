namespace BugJumper.Models
{
    using BugJumper.Config;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    /// <summary>
    /// A configuration object
    /// Original source:
    /// https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    /// </summary>
    public partial class ConfigurationData : DynamicObject, IDictionary<string, object>, IObservable<ConfigurationData>
    {
        public ConfigurationData Parent { get; private set; }
        private IConfigProvider provider;

        internal ConcurrentDictionary<string, object> members = new ConcurrentDictionary<string, object>();
        private List<IObserver<ConfigurationData>> observers = new List<IObserver<ConfigurationData>>();

        public ConfigurationData() : this((ConfigurationData)null)
        {
        }

        public ConfigurationData(ConfigurationData parent) : this(parent, null)
        {
        }

        public ConfigurationData(IConfigProvider provider) : this(null, null, provider)
        {
            this.provider = provider;
        }

        public ConfigurationData(ConfigurationData parent, IDictionary<string, object> dictionary) : this(parent, dictionary, parent?.provider ?? new JsonConfigProvider(string.Empty))
        {
        }

        public ConfigurationData(ConfigurationData parent, IDictionary<string, object> dictionary, IConfigProvider provider)
        {
            this.provider = provider;
            this.Parent = parent;

            if (null != dictionary && dictionary.Any())
            {
                this.AddRange(dictionary);
            }
        }

        public void AddRange(IDictionary<string, object> dictionary)
        {
            if (null == dictionary)
            {
                throw new ArgumentNullException("dictionary");
            }

            foreach (var kvp in dictionary)
            {
                members[kvp.Key] = provider.ProcessProperties(this, dictionary[kvp.Key]);
            }
        }

        public void Clear(string key)
        {

        }

        public void Notify(ConfigurationData obj)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(obj);
            }

            if (null != this.Parent)
            {
                this.Parent.Notify(obj);
            }
        }

        public IDisposable Subscribe(IObserver<ConfigurationData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber<ConfigurationData>(observers, observer);
        }
    }
}