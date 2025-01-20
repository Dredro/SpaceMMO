using System.Collections.Generic;

namespace PlayerSystem
{
    public interface ISubject
    {
        List<IObserver> Observers { get; set; }
        public void AttachObserver(IObserver observer);
        public void DetachObserver(IObserver observer);
        public void NotifyObservers(string message);
    }
}