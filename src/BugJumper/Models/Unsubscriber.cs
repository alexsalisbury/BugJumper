namespace BugJumper.Models
{
    using System;
    using System.Collections.Generic;

    /// Original source:
    /// https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    public class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> observers;
        private IObserver<T> observer;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            this.observers = observers;
            this.observer = observer;

            // TODO: Should auto add or depend on caller to add?
        }

        public void Dispose()
        {
            //TODO: Should prevent scenarios where observer is null?
            //                      observers?.Contains(observer)??false  
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}