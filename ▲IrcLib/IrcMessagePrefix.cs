﻿using System;

namespace TriangleIrcLib
{
    public class IrcMessagePrefix
    {
        public string Name
        {
            get;
            private set;
        }

        public string User
        {
            get;
            private set;
        }

        public string Host
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return  ":" + (Name != null ? Name + "!" : "") + (User != null ? User + "@" : "") + Host;
        }

        public IrcMessagePrefix(string name, string user, string host)
        {
            Name = name;
            User = user;
            Host = host;
        }

        public static IrcMessagePrefix Parse(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                throw new ArgumentNullException();

            string name, user, host;

            if (prefix[0] == ':')
                prefix = prefix.Substring(1);

            int nameEnd = prefix.IndexOf('!');

            if (nameEnd > 0)
            {
                name = prefix.Substring(0, nameEnd);

                int userEnd = prefix.IndexOf('@');
                user = prefix.Substring(nameEnd + 1, userEnd - nameEnd - 1);
                host = prefix.Substring(userEnd + 1);
            }
            else
            {
                name = null;
                user = null;
                host = prefix;
            }

            return new IrcMessagePrefix(name, user, host);
        }
    }
}
