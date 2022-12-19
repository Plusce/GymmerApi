namespace Gymmer.Core.Models;

public abstract record ValidationMessage(string Message)
{
    public string Message = Message;
}