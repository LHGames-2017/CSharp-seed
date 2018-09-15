using LHGames.DataStructures;
using System;

namespace LHGames
{
    public enum MessageType
    {
        Connect,
        BeginTurn,
        Action,
        Ping
    }

    public interface IMessage
    {
        MessageType Type { get; }
        string Content { get; }
    }

    public class Message : IMessage
    {
        public MessageType Type { get; set; }
        public string Content { get; set; }

        public Message(MessageType type, string content = "")
        {
            Type = type;
            Content = content;
        }
    }
}