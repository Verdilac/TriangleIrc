namespace TriangleIrcLib.Response
{
    /// <summary>
    /// Provides IRC error codes.
    /// </summary>
    public static class IrcError
    {
        /// <summary>
        /// Used to indicate the nickname parameter supplied to a command is currently unused
        /// <para> Format: &lt;nick&gt; :&lt;reason&gt; </para>
        /// <para> Value: 401</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOSUCHNICK = 401;

        /// <summary>
        /// Used to indicate the server name given currently doesn\'t exist
        /// <para> Format: &lt;server&gt; :&lt;reason&gt; </para>
        /// <para> Value: 402</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOSUCHSERVER = 402;

        /// <summary>
        /// Used to indicate the given channel name is invalid, or does not exist
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 403</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOSUCHCHANNEL = 403;

        /// <summary>
        /// Sent to a user who does not have the rights to send a message to a channel
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 404</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_CANNOTSENDTOCHAN = 404;

        /// <summary>
        /// Sent to a user when they have joined the maximum number of allowed channels and they tried to join another channel
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 405</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_TOOMANYCHANNELS = 405;

        /// <summary>
        /// Returned by WHOWAS to indicate there was no history information for a given nickname
        /// <para> Format: &lt;nick&gt; :&lt;reason&gt; </para>
        /// <para> Value: 406</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_WASNOSUCHNICK = 406;

        /// <summary>
        /// The given target(s) for a command are ambiguous in that they relate to too many targets
        /// <para> Format: &lt;target&gt; :&lt;reason&gt; </para>
        /// <para> Value: 407</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_TOOMANYTARGETS = 407;

        /// <summary>
        /// Returned to a client which is attempting to send an SQUERY (or other message) to a service which does not exist
        /// <para> Format: &lt;service_name&gt; :&lt;reason&gt; </para>
        /// <para> Value: 408</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_NOSUCHSERVICE = 408;

        /// <summary>
        /// PING or PONG message missing the originator parameter which is required since these commands must work without valid prefixes
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 409</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOORIGIN = 409;

        /// <summary>
        /// Returned when no recipient is given with a command
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 411</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NORECIPIENT = 411;

        /// <summary>
        /// Returned when NOTICE/PRIVMSG is used with no message given
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 412</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOTEXTTOSEND = 412;

        /// <summary>
        /// Used when a message is being sent to a mask without being limited to a top-level domain (i.e. * instead of *.au)
        /// <para> Format: &lt;mask&gt; :&lt;reason&gt; </para>
        /// <para> Value: 413</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOTOPLEVEL = 413;

        /// <summary>
        /// Used when a message is being sent to a mask with a wild-card for a top level domain (i.e. *.*)
        /// <para> Format: &lt;mask&gt; :&lt;reason&gt; </para>
        /// <para> Value: 414</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_WILDTOPLEVEL = 414;

        /// <summary>
        /// Used when a message is being sent to a mask with an invalid syntax
        /// <para> Format: &lt;mask&gt; :&lt;reason&gt; </para>
        /// <para> Value: 415</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_BADMASK = 415;

        /// <summary>
        /// Returned when the given command is unknown to the server (or hidden because of lack of access rights)
        /// <para> Format: &lt;command&gt; :&lt;reason&gt; </para>
        /// <para> Value: 421</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_UNKNOWNCOMMAND = 421;

        /// <summary>
        /// Sent when there is no MOTD to send the client
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 422</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOMOTD = 422;

        /// <summary>
        /// Returnedby a server in response to an ADMIN request when no information isavailable. RFC1459 mentions this in the list of numerics. While it\'snot listed as a valid reply in section 4.3.7 (\'Admin command\'), it\'sconfirmed to exist in the real world.
        /// <para> Format: &lt;server&gt; :&lt;reason&gt; </para>
        /// <para> Value: 423</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOADMININFO = 423;

        /// <summary>
        /// Generic error message used to report a failed file operation during the processing of a command
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 424</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_FILEERROR = 424;

        /// <summary>
        /// Returned when a nickname parameter expected for a command isn\'t found
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 431</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NONICKNAMEGIVEN = 431;

        /// <summary>
        /// Returnedafter receiving a NICK message which contains a nickname which isconsidered invalid, such as it\'s reserved (\'anonymous\') or containscharacters considered invalid for nicknames. This numeric is misspelt,but remains with this name for historical reasons :)
        /// <para> Format: &lt;nick&gt; :&lt;reason&gt; </para>
        /// <para> Value: 432</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_ERRONEUSNICKNAME = 432;

        /// <summary>
        /// Returned by the NICK command when the given nickname is already in use
        /// <para> Format: &lt;nick&gt; :&lt;reason&gt; </para>
        /// <para> Value: 433</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NICKNAMEINUSE = 433;

        /// <summary>
        /// Returned by a server to a client when it detects a nickname collision
        /// <para> Format: &lt;nick&gt; :&lt;reason&gt; </para>
        /// <para> Value: 436</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NICKCOLLISION = 436;

        /// <summary>
        /// Return when the target is unable to be reached temporarily, eg. a delay mechanism in play, or a service being offline
        /// <para> Format: &lt;nick/channel/service&gt; :&lt;reason&gt; </para>
        /// <para> Value: 437</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_UNAVAILRESOURCE = 437;

        /// <summary>
        /// Returned by the server to indicate that the target user of the command is not on the given channel
        /// <para> Format: &lt;nick&gt; &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 441</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_USERNOTINCHANNEL = 441;

        /// <summary>
        /// Returned by the server whenever a client tries to perform a channel effecting command for which the client is not a member
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 442</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOTONCHANNEL = 442;

        /// <summary>
        /// Returned when a client tries to invite a user to a channel they\'re already on
        /// <para> Format: &lt;nick&gt; &lt;channel&gt; [:&lt;reason&gt;] </para>
        /// <para> Value: 443</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_USERONCHANNEL = 443;

        /// <summary>
        /// Returned by the SUMMON command if a given user was not logged in and could not be summoned
        /// <para> Format: &lt;user&gt; :&lt;reason&gt; </para>
        /// <para> Value: 444</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOLOGIN = 444;

        /// <summary>
        /// Returned by SUMMON when it has been disabled or not implemented
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 445</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_SUMMONDISABLED = 445;

        /// <summary>
        /// Returned by USERS when it has been disabled or not implemented
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 446</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_USERSDISABLED = 446;

        /// <summary>
        /// Returned by the server to indicate that the client must be registered before the server will allow it to be parsed in detail
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 451</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOTREGISTERED = 451;

        /// <summary>
        /// Returned by the server by any command which requires more parameters than the number of parameters given
        /// <para> Format: &lt;command&gt; :&lt;reason&gt; </para>
        /// <para> Value: 461</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NEEDMOREPARAMS = 461;

        /// <summary>
        /// Returned by the server to any link which attempts to register again
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 462</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_ALREADYREGISTERED = 462;

        /// <summary>
        /// Returnedto a client which attempts to register with a server which has beenconfigured to refuse connections from the client\'s host
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 463</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOPERMFORHOST = 463;

        /// <summary>
        /// Returned by the PASS command to indicate the given password was required and was either not given or was incorrect
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 464</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_PASSWDMISMATCH = 464;

        /// <summary>
        /// Returned to a client after an attempt to register on a server configured to ban connections from that client
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 465</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_YOUREBANNEDCREEP = 465;

        /// <summary>
        /// Sent by a server to a user to inform that access to the server will soon be denied
        /// <para> Format:  </para>
        /// <para> Value: 466</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_YOUWILLBEBANNED = 466;

        /// <summary>
        /// Returned when the channel key for a channel has already been set
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 467</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_KEYSET = 467;

        /// <summary>
        /// Returned when attempting to join a channel which is set +l and is already full
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 471</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_CHANNELISFULL = 471;

        /// <summary>
        /// Returned when a given mode is unknown
        /// <para> Format: &lt;char&gt; :&lt;reason&gt; </para>
        /// <para> Value: 472</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_UNKNOWNMODE = 472;

        /// <summary>
        /// Returned when attempting to join a channel which is invite only without an invitation
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 473</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_INVITEONLYCHAN = 473;

        /// <summary>
        /// Returned when attempting to join a channel a user is banned from
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 474</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_BANNEDFROMCHAN = 474;

        /// <summary>
        /// Returned when attempting to join a key-locked channel either without a key or with the wrong key
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 475</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_BADCHANNELKEY = 475;

        /// <summary>
        /// The given channel mask was invalid
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 476</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_BADCHANMASK = 476;

        /// <summary>
        /// Returnedwhen attempting to set a mode on a channel which does not supportchannel modes, or channel mode changes. Also known as ERR_MODELESS
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 477</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_NOCHANMODES = 477;

        /// <summary>
        /// Returned when a channel access list (i.e. ban list etc) is full and cannot be added to
        /// <para> Format: &lt;channel&gt; &lt;char&gt; :&lt;reason&gt; </para>
        /// <para> Value: 478</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_BANLISTFULL = 478;

        /// <summary>
        /// Returned by any command requiring special privileges (eg. IRC operator) to indicate the operation was unsuccessful
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 481</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOPRIVILEGES = 481;

        /// <summary>
        /// Returned by any command requiring special channel privileges (eg. channel operator) to indicate the operation was unsuccessful
        /// <para> Format: &lt;channel&gt; :&lt;reason&gt; </para>
        /// <para> Value: 482</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_CHANOPRIVSNEEDED = 482;

        /// <summary>
        /// Returned by KILL to anyone who tries to kill a server
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 483</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_CANTKILLSERVER = 483;

        /// <summary>
        /// Sent by the server to a user upon connection to indicate the restricted nature of the connection (i.e. usermode +r)
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 484</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_RESTRICTED = 484;

        /// <summary>
        /// Anymode requiring \'channel creator\' privileges returns this error if theclient is attempting to use it while not a channel creator on the givenchannel
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 485</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int ERR_UNIQOPRIVSNEEDED = 485;

        /// <summary>
        /// Returnedby OPER to a client who cannot become an IRC operator because theserver has been configured to disallow the client\'s host
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 491</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOOPERHOST = 491;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 492</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_NOSERVICEHOST = 492;

        /// <summary>
        /// Returnedby the server to indicate that a MODE message was sent with a nicknameparameter and that the mode flag sent was not recognised
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 501</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_UMODEUNKNOWNFLAG = 501;

        /// <summary>
        /// Error sent to any user trying to view or change the user mode for a user other than themselves
        /// <para> Format: :&lt;reason&gt; </para>
        /// <para> Value: 502</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int ERR_USERSDONTMATCH = 502;
    }
}
