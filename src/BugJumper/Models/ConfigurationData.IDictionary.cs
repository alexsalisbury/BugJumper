namespace BugJumper.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This partial implementation of ConfigurationData implements IDictionary<string, object>
    /// Original source:
    /// https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    /// </summary>
    public partial class ConfigurationData
    {
        public dynamic this[string key]
        {
            get
            {
                if (members.ContainsKey(key))
                {
                    return members[key];
                }

                return new ConfigurationData(this);
            }
            set
            {
                var processedValue = provider.ProcessProperties(this, value as dynamic);
                members[key] = processedValue;
            }
        }

        public dynamic this[int index]
        {
            get
            {
                var key = index.ToString();
                return this[key];
            }
            set
            {
                var processedValue = provider.ProcessProperties(this, value as dynamic);
                members[index.ToString()] = processedValue;
            }
        }

        public ICollection<string> Keys => members.Keys;

        public ICollection<object> Values => members.Values;

        public int Count => members.Count;

        public bool IsReadOnly => false;

        public void Add(string key, object value) => this.Add(key, value, false);

        public void Add(KeyValuePair<string, object> item) => this.Add(item.Key, item.Value, false);

        public bool TryAdd(string key, object value) => this.Add(key, value, true);

        public bool TryAdd(KeyValuePair<string, object> item) => this.Add(item.Key, item.Value, true);

        private bool Add(string key, object value, bool isTry)
        {
            Regex r = new Regex("^[a-zA-Z]+[a-zA-Z0-9_]*$");
            if (!r.IsMatch(key))
            {
                if (isTry)
                {
                    return false;
                }

                throw new ArgumentException("Invalid key name");
            }

            return members.TryAdd(key, value);
        }

        public void Clear() => members.Clear();

        public bool Contains(KeyValuePair<string, object> item)
        {
            return members.ContainsKey(item.Key) && members[item.Key] == item.Value;
        }

        public bool ContainsKey(string key) => members.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            var keys = members.ToArray();
            foreach (var k in keys)
            {
                yield return k;
            }
        }

        public bool Remove(string key) => members.TryRemove(key, out _);

        public bool Remove(KeyValuePair<string, object> item)
        {
            if (members.ContainsKey(item.Key) && members[item.Key] == item.Value)
            {
                return members.TryRemove(item.Key, out _);
            }

            return false;
        }

        public bool TryRemove(string key, out object value) => members.TryRemove(key, out value);

        //public bool TryRemove(KeyValuePair<string, object> item, out KeyValuePair<string, object> value)
        //{
        //    object keyValue;
        //    //issues with boxing here.
        //    if (members.ContainsKey(item.Key) && members[item.Key] == item.Value)
        //    {
        //        var result = members.TryRemove(item.Key, out keyValue);
        //        // Still the potential for contention here. Need to assess scenario when item.Value != keyValue.
        //        // Behavior undefined in that scenario, I think.
        //        value = new KeyValuePair<string, object>(item.Key, keyValue);
        //        return result;
        //    }

        //    return false;
        //}

        public bool TryGetValue(string key, out object value) => members.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => members.GetEnumerator();
    }
}