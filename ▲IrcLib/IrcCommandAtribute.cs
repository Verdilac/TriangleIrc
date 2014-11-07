using System;

namespace TriangleIrcLib
{
    /// <summary>
    /// Specifies command for which the method will be invoked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class IrcCommandAttribute : Attribute
    {
        /// <summary>
        /// Gets an irc command for which the method will be invoked.
        /// </summary>
        public string Command
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the TriangleIrcLib.IrcCommandAttribute
        /// with the specified command.
        /// </summary>
        /// <param name="command">Command string.</param>
        public IrcCommandAttribute(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the TriangleIrcLib.IrcCommandAttribute
        /// with the specified numeric  command.
        /// </summary>
        /// <param name="numericResponse">IRC numeric response.</param>
        public IrcCommandAttribute(int numericResponse)
        {
            Command = numericResponse.ToString();
        }
    }
}
