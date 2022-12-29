using Gymmer.Core.Models;

namespace Gymmer.Core.Extensions;

public static class ValidationMessageExtensions
{
    public static ValidationMessage AddParams(this ValidationMessage message, params string[] arguments)
    {
        for (var i = 0; i < arguments.Length; i++)
        {
            message.Message = message.Message.Replace($"{{{i}}}", arguments[i]);
        }

        return message;
    }
}