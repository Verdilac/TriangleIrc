using System;
using System.Linq;

namespace TriangleIrcLib
{
    /// <summary>
    /// Represent IRC server message.
    /// </summary>
    public class IrcMessage
    {
        /// <summary>
        /// True origin of message.
        /// </summary>
        public string Prefix
        {
            get;
            private set;
        }

        /// <summary>
        /// IRC Command.
        /// </summary>
        public string Command
        {
            get;
            private set;
        }

        /// <summary>
        /// Up to 15 command parameters.
        /// </summary>
        public string[] Parameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Trailing parameter which can contain spaces.
        /// </summary>
        public string Trailing
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the TriangleIrcLib.IrcMessage class.
        /// </summary>
        /// <param name="prefix">True origin of message. (optional)</param>
        /// <param name="command">IRC Command.</param>
        /// <param name="trailing">Up to 15 command parameters. (optional)</param>
        /// <param name="parameters">Trailing parameter which can contain spaces. (optional)</param>
        public IrcMessage(string prefix, string command, string[] parameters, string trailing)
        {
            Prefix = prefix;
            Command = command;
            Parameters = parameters;
            Trailing = trailing;
        }

        /// <summary>
        /// Returns prefix, command and parameters joined into valid IRC message.
        /// </summary>
        /// <returns>Valid IRC message.</returns>
        public override string ToString()
        {
            string retVal = "";
            if (!String.IsNullOrEmpty(Prefix))
                retVal += ":" + Prefix + " ";

            retVal += Command;
            if (Parameters != null && Parameters.Length > 0)
                retVal += " " + String.Join(" ", Parameters);

            if (!String.IsNullOrEmpty(Trailing))
                retVal += " :" + Trailing;

            return retVal;
        }

        /// <summary>
        /// Validates IRC message and converts it into new TriangleIrcLib.IrcMessage instance.
        /// </summary>
        /// <param name="message">IRC message</param>
        public static IrcMessage Parse(string message)
        {
            string prefix, command, trailing;
            prefix = command = trailing = null;
            string[] parameters = null;

            int prefixEnd = -1;
            if (message.StartsWith(":"))
            {
                prefixEnd = message.IndexOf(" ");
                prefix = message.Substring(1, prefixEnd - 1);
            }

            int trailingStart = message.IndexOf(" :");
            if (trailingStart > 0)
                trailing = message.Substring(trailingStart + 2);
            else
                trailingStart = message.Length;

            string[] commandAndParameters = message.Substring(
                prefixEnd + 1, trailingStart - prefixEnd - 1).Split(' ');

            if (commandAndParameters.Length == 0)
                throw new FormatException("There is no command in IRC message.");

            command = commandAndParameters.First();

            if (commandAndParameters.Length > 1)
                parameters = commandAndParameters.Skip(1).ToArray();

            return new IrcMessage(prefix, command, parameters, trailing);
        }
    }
}
