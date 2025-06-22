using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class NotifierDecorator: Notifier
{
    protected Notifier notify;

    public NotifierDecorator(Notifier notification)
    {
        notify = notification;
    }

    public virtual void Send(string message)
    {
        notify.Send(message);
    }
}
