using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Stock
{
    void Register(Observer observer);
    void Deregister(Observer observer);
    void NotifyObservers();
}