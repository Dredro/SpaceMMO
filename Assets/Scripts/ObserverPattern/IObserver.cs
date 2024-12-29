using System;

public interface IObserver
{
    public void Notify(ISubject subject,string message);
}