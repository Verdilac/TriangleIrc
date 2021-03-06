﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        public IrcMessagePrefix Prefix
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

        public bool IsCtcp
        {
            get { return Trailing != null && Trailing[0] == 1 && Trailing[Trailing.Length - 1] == 1; }
        }

        /// <summary>
        /// Initializes a new instance of the TriangleIrcLib.IrcMessage class.
        /// </summary>
        /// <param name="prefix">True origin of message.</param>
        /// <param name="command">IRC Command.</param>
        /// <param name="trailing">Up to 15 command parameters.</param>
        /// <param name="parameters">Trailing parameter which can contain spaces.</param>
        public IrcMessage(string prefix, string command, string[] parameters, string trailing)
        {
            Prefix = String.IsNullOrEmpty(prefix) ? null : IrcMessagePrefix.Parse(prefix);
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
            if (Prefix != null)
                retVal += Prefix + " ";

            retVal += Command;
            if (Parameters != null && Parameters.Length > 0)
                retVal += " " + String.Join(" ", Parameters);

            if (!String.IsNullOrEmpty(Trailing))
                retVal += " :" + Trailing;

            return retVal;
        }

        /// <summary>
        /// Validates the IRC message string and converts it into the new TriangleIrcLib.IrcMessage instance.
        /// </summary>
        /// <param name="message">IRC message</param>
        public static IrcMessage Parse(string message)
        {
            string trailing;
            string prefix = trailing = null;
            string[] parameters = null;

            // Look for prefix.
            int prefixEnd = -1;
            if (message.StartsWith(":"))
            {
                prefixEnd = message.IndexOf(" ");
                prefix = message.Substring(1, prefixEnd - 1);
            }

            // Look for trailing parameter.
            int trailingStart = message.IndexOf(" :");
            if (trailingStart > 0)
                trailing = message.Substring(trailingStart + 2);
            else
                trailingStart = message.Length;

            // Look for command and non-trailing parameters.
            var commandAndParameters = message.Substring(prefixEnd + 1, trailingStart - prefixEnd - 1).Split(' ');

            if (commandAndParameters.Length == 0)
                throw new FormatException("There is no command in IRC message.");

            var command = commandAndParameters.First();

            if (commandAndParameters.Length > 1)
                parameters = commandAndParameters.Skip(1).ToArray();

            if (parameters != null && parameters.Length + (trailing != null ? 1 : 0) > 15)
                throw new FormatException("There cannot be more than 15 parameters.");

            return new IrcMessage(prefix, command, parameters, trailing);
        }
    }
}
