using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RemoteControl
{
    private Command _command;

    public void SetCommand(Command command)
    {
        _command = command;
    }

    public void PressButton()
    {
        if (_command != null)
        {
            _command.Execute();
        }
        else
        {
            System.Console.WriteLine("No command assigned.");
        }
    }
}