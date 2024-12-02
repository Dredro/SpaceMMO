
public class Stats : ISubject
{
    public int Health { get; set; }
    public int Energy {get;set;}
    public List<IObserver> Observers {get; set;} = [];

    public void AttachObserver(IObserver observer)
    {
        if(Observers.Contains(observer)) return;
        Observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        if(!Observers.Contains(observer)) return;
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
       foreach(var observer in Observers)observer.Notify();
    }
}