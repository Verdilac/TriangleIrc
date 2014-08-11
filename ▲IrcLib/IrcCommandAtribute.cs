using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleIrcLib
{
    /// <summary>
    /// Specifies command for which the method will be invoked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
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
        /// <param name="command"></param>
        public IrcCommandAttribute(string command)
        {
            Command = command;
        }
    }
}
