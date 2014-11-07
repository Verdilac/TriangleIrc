namespace TriangleIrcLib.Response
{
    /// <summary>
    /// Provides IRC response codes.
    /// </summary>
    public static class IrcResponse
    {
        /// <summary>
        /// The first message sent after client registration. The text used varies widely
        /// <para> Format: :Welcome to the Internet Relay Network &lt;nick&gt;!&lt;user&gt;@&lt;host&gt; </para>
        /// <para> Value: 001</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_WELCOME = 1;

        /// <summary>
        /// Part of the post-registration greeting. Text varies widely
        /// <para> Format: :Your host is &lt;servername&gt;, running version &lt;version&gt; </para>
        /// <para> Value: 002</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_YOURHOST = 2;

        /// <summary>
        /// Part of the post-registration greeting. Text varies widely
        /// <para> Format: :This server was created &lt;date&gt; </para>
        /// <para> Value: 003</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_CREATED = 3;

        /// <summary>
        /// Part of the post-registration greeting
        /// <para> Format: &lt;server_name&gt; &lt;version&gt; &lt;user_modes&gt; &lt;chan_modes&gt; </para>
        /// <para> Value: 004</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_MYINFO = 4;

        /// <summary>
        /// None
        /// <para> Format: :Try server &lt;server_name&gt;, port &lt;port_number&gt; </para>
        /// <para> Value: 005</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_BOUNCE = 5;

        /// <summary>
        /// See RFC
        /// <para> Format: Link&lt;version&gt;[.&lt;debug_level&gt;] &lt;destination&gt;&lt;next_server&gt; [V&lt;protocol_version&gt;&lt;link_uptime_in_seconds&gt; &lt;backstream_sendq&gt;&lt;upstream_sendq&gt;] </para>
        /// <para> Value: 200</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACELINK = 200;

        /// <summary>
        /// See RFC
        /// <para> Format: Try. &lt;class&gt; &lt;server&gt; </para>
        /// <para> Value: 201</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACECONNECTING = 201;

        /// <summary>
        /// See RFC
        /// <para> Format: H.S. &lt;class&gt; &lt;server&gt; </para>
        /// <para> Value: 202</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACEHANDSHAKE = 202;

        /// <summary>
        /// See RFC
        /// <para> Format: ???? &lt;class&gt; [&lt;connection_address&gt;] </para>
        /// <para> Value: 203</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACEUNKNOWN = 203;

        /// <summary>
        /// See RFC
        /// <para> Format: Oper &lt;class&gt; &lt;nick&gt; </para>
        /// <para> Value: 204</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACEOPERATOR = 204;

        /// <summary>
        /// See RFC
        /// <para> Format: User &lt;class&gt; &lt;nick&gt; </para>
        /// <para> Value: 205</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACEUSER = 205;

        /// <summary>
        /// See RFC
        /// <para> Format: Serv&lt;class&gt; &lt;int&gt;S &lt;int&gt;C &lt;server&gt;&lt;nick!user|*!*&gt;@&lt;host|server&gt; [V&lt;protocol_version&gt;] </para>
        /// <para> Value: 206</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACESERVER = 206;

        /// <summary>
        /// See RFC
        /// <para> Format: Service &lt;class&gt; &lt;name&gt; &lt;type&gt; &lt;active_type&gt; </para>
        /// <para> Value: 207</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_TRACESERVICE = 207;

        /// <summary>
        /// See RFC
        /// <para> Format: &lt;newtype&gt; 0 &lt;client_name&gt; </para>
        /// <para> Value: 208</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACENEWTYPE = 208;

        /// <summary>
        /// See RFC
        /// <para> Format: Class &lt;class&gt; &lt;count&gt; </para>
        /// <para> Value: 209</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_TRACECLASS = 209;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 210</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_TRACERECONNECT = 210;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: &lt;linkname&gt; &lt;sendq&gt; &lt;sent_msgs&gt; &lt;sent_bytes&gt; &lt;recvd_msgs&gt; &lt;rcvd_bytes&gt; &lt;time_open&gt; </para>
        /// <para> Value: 211</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSLINKINFO = 211;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: &lt;command&gt; &lt;count&gt; [&lt;byte_count&gt; &lt;remote_count&gt;] </para>
        /// <para> Value: 212</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSCOMMANDS = 212;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: C &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt; </para>
        /// <para> Value: 213</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSCLINE = 213;

        /// <summary>
        /// Reply to STATS (See RFC), Also known as RPL_STATSOLDNLINE (ircu, Unreal)
        /// <para> Format: N &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt; </para>
        /// <para> Value: 214</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSNLINE = 214;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: I &lt;host&gt; * &lt;host&gt; &lt;port&gt; &lt;class&gt; </para>
        /// <para> Value: 215</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSILINE = 215;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: K &lt;host&gt; * &lt;username&gt; &lt;port&gt; &lt;class&gt; </para>
        /// <para> Value: 216</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSKLINE = 216;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 217</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSQLINE = 217;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: Y &lt;class&gt; &lt;ping_freq&gt; &lt;connect_freq&gt; &lt;max_sendq&gt; </para>
        /// <para> Value: 218</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSYLINE = 218;

        /// <summary>
        /// End of RPL_STATS* list.
        /// <para> Format: &lt;query&gt; :&lt;info&gt; </para>
        /// <para> Value: 219</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFSTATS = 219;

        /// <summary>
        /// Informationabout a user\'s own modes. Some daemons have extended the mode commandand certain modes take parameters (like channel modes).
        /// <para> Format: &lt;user_modes&gt; [&lt;user_mode_params&gt;] </para>
        /// <para> Value: 221</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_UMODEIS = 221;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 231</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_SERVICEINFO = 231;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 232</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFSERVICES = 232;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 233</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_SERVICE = 233;

        /// <summary>
        /// A service entry in the service list
        /// <para> Format: &lt;name&gt; &lt;server&gt; &lt;mask&gt; &lt;type&gt; &lt;hopcount&gt; &lt;info&gt; </para>
        /// <para> Value: 234</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_SERVLIST = 234;

        /// <summary>
        /// Termination of an RPL_SERVLIST list
        /// <para> Format: &lt;mask&gt; &lt;type&gt; :&lt;info&gt; </para>
        /// <para> Value: 235</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_SERVLISTEND = 235;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 240</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_STATSVLINE = 240;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: L &lt;hostmask&gt; * &lt;servername&gt; &lt;maxdepth&gt; </para>
        /// <para> Value: 241</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSLLINE = 241;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: :Server Up &lt;days&gt; days &lt;hours&gt;:&lt;minutes&gt;:&lt;seconds&gt; </para>
        /// <para> Value: 242</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSUPTIME = 242;

        /// <summary>
        /// Replyto STATS (See RFC); The info field is an extension found in some IRCdaemons, which returns info such as an e-mail address or the name/jobof an operator
        /// <para> Format: O &lt;hostmask&gt; * &lt;nick&gt; [:&lt;info&gt;] </para>
        /// <para> Value: 243</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSOLINE = 243;

        /// <summary>
        /// Reply to STATS (See RFC)
        /// <para> Format: H &lt;hostmask&gt; * &lt;servername&gt; </para>
        /// <para> Value: 244</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_STATSHLINE = 244;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 246</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_STATSPING = 246;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 247</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_STATSBLINE = 247;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 250</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_STATSDLINE = 250;

        /// <summary>
        /// Reply to LUSERS command, other versions exist (eg. RFC2812); Text may vary.
        /// <para> Format: :There are &lt;int&gt; users and &lt;int&gt; invisible on &lt;int&gt; servers </para>
        /// <para> Value: 251</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LUSERCLIENT = 251;

        /// <summary>
        /// Reply to LUSERS command - Number of IRC operators online
        /// <para> Format: &lt;int&gt; :&lt;info&gt; </para>
        /// <para> Value: 252</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LUSEROP = 252;

        /// <summary>
        /// Reply to LUSERS command - Number of unknown/unregistered connections
        /// <para> Format: &lt;int&gt; :&lt;info&gt; </para>
        /// <para> Value: 253</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LUSERUNKNOWN = 253;

        /// <summary>
        /// Reply to LUSERS command - Number of channels formed
        /// <para> Format: &lt;int&gt; :&lt;info&gt; </para>
        /// <para> Value: 254</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LUSERCHANNELS = 254;

        /// <summary>
        /// Reply to LUSERS command - Information about local connections; Text may vary.
        /// <para> Format: :I have &lt;int&gt; clients and &lt;int&gt; servers </para>
        /// <para> Value: 255</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LUSERME = 255;

        /// <summary>
        /// Startof an RPL_ADMIN* reply. In practise, the server parameter is oftennever given, and instead the info field contains the text\'Administrative info about &lt;server&gt;\'. Newer daemons seem tofollow the RFC and output the server\'s hostname in the \'server\'parameter, but also output the server name in the text as pertraditional daemons.
        /// <para> Format: &lt;server&gt; :&lt;info&gt; </para>
        /// <para> Value: 256</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ADMINME = 256;

        /// <summary>
        /// Reply to ADMIN command (Location, first line)
        /// <para> Format: :&lt;admin_location&gt; </para>
        /// <para> Value: 257</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ADMINLOC1 = 257;

        /// <summary>
        /// Reply to ADMIN command (Location, second line)
        /// <para> Format: :&lt;admin_location&gt; </para>
        /// <para> Value: 258</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ADMINLOC2 = 258;

        /// <summary>
        /// Reply to ADMIN command (E-mail address of administrator)
        /// <para> Format: :&lt;email_address&gt; </para>
        /// <para> Value: 259</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ADMINEMAIL = 259;

        /// <summary>
        /// See RFC
        /// <para> Format: File &lt;logfile&gt; &lt;debug_level&gt; </para>
        /// <para> Value: 261</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TRACELOG = 261;

        /// <summary>
        /// Used to terminate a list of RPL_TRACE* replies
        /// <para> Format: &lt;server_name&gt; &lt;version&gt;[.&lt;debug_level&gt;] :&lt;info&gt; </para>
        /// <para> Value: 262</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_TRACEEND = 262;

        /// <summary>
        /// Whena server drops a command without processing it, it MUST use this reply.Also known as RPL_LOAD_THROTTLED and RPL_LOAD2HI, I\'m presuming they dothe same thing.
        /// <para> Format: &lt;command&gt; :&lt;info&gt; </para>
        /// <para> Value: 263</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_TRYAGAIN = 263;

        /// <summary>
        /// Dummy reply, supposedly only used for debugging/testing new features, however has appeared in production daemons.
        /// <para> Format:  </para>
        /// <para> Value: 300</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_NONE = 300;

        /// <summary>
        /// Used in reply to a command directed at a user who is marked as away
        /// <para> Format: &lt;nick&gt; :&lt;message&gt; </para>
        /// <para> Value: 301</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_AWAY = 301;

        /// <summary>
        /// Reply used by USERHOST (see RFC)
        /// <para> Format: :*1&lt;reply&gt; *( \' \' &lt;reply&gt; ) </para>
        /// <para> Value: 302</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_USERHOST = 302;

        /// <summary>
        /// Reply to the ISON command (see RFC)
        /// <para> Format: :*1&lt;nick&gt; *( \' \' &lt;nick&gt; ) </para>
        /// <para> Value: 303</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ISON = 303;

        /// <summary>
        /// Reply from AWAY when no longer marked as away
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 305</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_UNAWAY = 305;

        /// <summary>
        /// Reply from AWAY when marked away
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 306</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_NOWAWAY = 306;

        /// <summary>
        /// Reply to WHOIS - Information about the user
        /// <para> Format: &lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real_name&gt; </para>
        /// <para> Value: 311</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISUSER = 311;

        /// <summary>
        /// Reply to WHOIS - What server they\'re on
        /// <para> Format: &lt;nick&gt; &lt;server&gt; :&lt;server_info&gt; </para>
        /// <para> Value: 312</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISSERVER = 312;

        /// <summary>
        /// Reply to WHOIS - User has IRC Operator privileges
        /// <para> Format: &lt;nick&gt; :&lt;privileges&gt; </para>
        /// <para> Value: 313</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISOPERATOR = 313;

        /// <summary>
        /// Reply to WHOWAS - Information about the user
        /// <para> Format: &lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real_name&gt; </para>
        /// <para> Value: 314</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOWASUSER = 314;

        /// <summary>
        /// Used to terminate a list of RPL_WHOREPLY replies
        /// <para> Format: &lt;name&gt; :&lt;info&gt; </para>
        /// <para> Value: 315</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFWHO = 315;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 316</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISCHANOP = 316;

        /// <summary>
        /// Reply to WHOIS - Idle information
        /// <para> Format: &lt;nick&gt; &lt;seconds&gt; :seconds idle </para>
        /// <para> Value: 317</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISIDLE = 317;

        /// <summary>
        /// Reply to WHOIS - End of list
        /// <para> Format: &lt;nick&gt; :&lt;info&gt; </para>
        /// <para> Value: 318</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFWHOIS = 318;

        /// <summary>
        /// Reply to WHOIS - Channel list for user (See RFC)
        /// <para> Format: &lt;nick&gt; :*( ( \'@\' / \'+\' ) &lt;channel&gt; \' \' ) </para>
        /// <para> Value: 319</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOISCHANNELS = 319;

        /// <summary>
        /// Channel list - Header
        /// <para> Format: Channels :Users  Name </para>
        /// <para> Value: 321</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LISTSTART = 321;

        /// <summary>
        /// Channel list - A channel
        /// <para> Format: &lt;channel&gt; &lt;#_visible&gt; :&lt;topic&gt; </para>
        /// <para> Value: 322</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LIST = 322;

        /// <summary>
        /// Channel list - End of list
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 323</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LISTEND = 323;

        /// <summary>
        /// 
        /// <para> Format: &lt;channel&gt; &lt;mode&gt; &lt;mode_params&gt; </para>
        /// <para> Value: 324</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_CHANNELMODEIS = 324;

        /// <summary>
        /// 
        /// <para> Format: &lt;channel&gt; &lt;nickname&gt; </para>
        /// <para> Value: 325</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_UNIQOPIS = 325;

        /// <summary>
        /// Response to TOPIC when no topic is set
        /// <para> Format: &lt;channel&gt; :&lt;info&gt; </para>
        /// <para> Value: 331</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_NOTOPIC = 331;

        /// <summary>
        /// Response to TOPIC with the set topic
        /// <para> Format: &lt;channel&gt; :&lt;topic&gt; </para>
        /// <para> Value: 332</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TOPIC = 332;

        /// <summary>
        /// Returnedby the server to indicate that the attempted INVITE message wassuccessful and is being passed onto the end client. Note that RFC1459documents the parameters in the reverse order. The format given here isthe format used on production servers, and should be considered thestandard reply above that given by RFC1459.
        /// <para> Format: &lt;nick&gt; &lt;channel&gt; </para>
        /// <para> Value: 341</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_INVITING = 341;

        /// <summary>
        /// Returned by a server answering a SUMMON message to indicate that it is summoning that user
        /// <para> Format: &lt;user&gt; :&lt;info&gt; </para>
        /// <para> Value: 342</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_SUMMONING = 342;

        /// <summary>
        /// An invite mask for the invite mask list
        /// <para> Format: &lt;channel&gt; &lt;invitemask&gt; </para>
        /// <para> Value: 346</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_INVITELIST = 346;

        /// <summary>
        /// Termination of an RPL_INVITELIST list
        /// <para> Format: &lt;channel&gt; :&lt;info&gt; </para>
        /// <para> Value: 347</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_ENDOFINVITELIST = 347;

        /// <summary>
        /// An exception mask for the exception mask list. Also known as RPL_EXLIST (Unreal, Ultimate)
        /// <para> Format: &lt;channel&gt; &lt;exceptionmask&gt; </para>
        /// <para> Value: 348</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_EXCEPTLIST = 348;

        /// <summary>
        /// Termination of an RPL_EXCEPTLIST list. Also known as RPL_ENDOFEXLIST (Unreal, Ultimate)
        /// <para> Format: &lt;channel&gt; :&lt;info&gt; </para>
        /// <para> Value: 349</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_ENDOFEXCEPTLIST = 349;

        /// <summary>
        /// Reply by the server showing its version details, however this format is not often adhered to
        /// <para> Format: &lt;version&gt;[.&lt;debuglevel&gt;] &lt;server&gt; :&lt;comments&gt; </para>
        /// <para> Value: 351</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_VERSION = 351;

        /// <summary>
        /// Reply to vanilla WHO (See RFC). This format can be very different if the \'WHOX\' version of the command is used (see ircu).
        /// <para> Format: &lt;channel&gt; &lt;user&gt; &lt;host&gt; &lt;server&gt; &lt;nick&gt; &lt;H|G&gt;[*][@|+] :&lt;hopcount&gt; &lt;real_name&gt; </para>
        /// <para> Value: 352</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_WHOREPLY = 352;

        /// <summary>
        /// Reply to NAMES (See RFC)
        /// <para> Format: ( \'=\' / \'*\' / \'@\' ) &lt;channel&gt; \' \' : [ \'@\' / \'+\' ] &lt;nick&gt; *( \' \' [ \'@\' / \'+\' ] &lt;nick&gt; ) </para>
        /// <para> Value: 353</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_NAMREPLY = 353;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 361</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_KILLDONE = 361;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 362</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_CLOSING = 362;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 363</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_CLOSEEND = 363;

        /// <summary>
        /// Reply to the LINKS command
        /// <para> Format: &lt;mask&gt; &lt;server&gt; :&lt;hopcount&gt; &lt;server_info&gt; </para>
        /// <para> Value: 364</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_LINKS = 364;

        /// <summary>
        /// Termination of an RPL_LINKS list
        /// <para> Format: &lt;mask&gt; :&lt;info&gt; </para>
        /// <para> Value: 365</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFLINKS = 365;

        /// <summary>
        /// Termination of an RPL_NAMREPLY list
        /// <para> Format: &lt;channel&gt; :&lt;info&gt; </para>
        /// <para> Value: 366</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFNAMES = 366;

        /// <summary>
        /// A ban-list item (See RFC); &lt;time left&gt; and &lt;reason&gt; are additions used by KineIRCd
        /// <para> Format: &lt;channel&gt; &lt;banid&gt; [&lt;time_left&gt; :&lt;reason&gt;] </para>
        /// <para> Value: 367</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_BANLIST = 367;

        /// <summary>
        /// Termination of an RPL_BANLIST list
        /// <para> Format: &lt;channel&gt; :&lt;info&gt; </para>
        /// <para> Value: 368</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFBANLIST = 368;

        /// <summary>
        /// Reply to WHOWAS - End of list
        /// <para> Format: &lt;nick&gt; :&lt;info&gt; </para>
        /// <para> Value: 369</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFWHOWAS = 369;

        /// <summary>
        /// Reply to INFO
        /// <para> Format: :&lt;string&gt; </para>
        /// <para> Value: 371</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_INFO = 371;

        /// <summary>
        /// Reply to MOTD
        /// <para> Format: :- &lt;string&gt; </para>
        /// <para> Value: 372</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_MOTD = 372;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 373</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_INFOSTART = 373;

        /// <summary>
        /// Termination of an RPL_INFO list
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 374</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFINFO = 374;

        /// <summary>
        /// Start of an RPL_MOTD list
        /// <para> Format: :- &lt;server&gt; Message of the day - </para>
        /// <para> Value: 375</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_MOTDSTART = 375;

        /// <summary>
        /// Termination of an RPL_MOTD list
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 376</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFMOTD = 376;

        /// <summary>
        /// Successful reply from OPER
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 381</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_YOUREOPER = 381;

        /// <summary>
        /// Successful reply from REHASH
        /// <para> Format: &lt;config_file&gt; :&lt;info&gt; </para>
        /// <para> Value: 382</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_REHASHING = 382;

        /// <summary>
        /// Sent upon successful registration of a service
        /// <para> Format: :You are service &lt;service_name&gt; </para>
        /// <para> Value: 383</para>
        /// <para> Origin: RFC2812 </para>
        /// </summary>
        public const int RPL_YOURESERVICE = 383;

        /// <summary>
        /// 
        /// <para> Format:  </para>
        /// <para> Value: 384</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_MYPORTIS = 384;

        /// <summary>
        /// None
        /// <para> Format: &lt;server&gt; :&lt;time string&gt; </para>
        /// <para> Value: 391</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_TIME = 391;

        /// <summary>
        /// Start of an RPL_USERS list
        /// <para> Format: :UserID   Terminal  Host </para>
        /// <para> Value: 392</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_USERSSTART = 392;

        /// <summary>
        /// Response to the USERS command (See RFC)
        /// <para> Format: :&lt;username&gt; &lt;ttyline&gt; &lt;hostname&gt; </para>
        /// <para> Value: 393</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_USERS = 393;

        /// <summary>
        /// Termination of an RPL_USERS list
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 394</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_ENDOFUSERS = 394;

        /// <summary>
        /// Reply to USERS when nobody is logged in
        /// <para> Format: :&lt;info&gt; </para>
        /// <para> Value: 395</para>
        /// <para> Origin: RFC1459 </para>
        /// </summary>
        public const int RPL_NOUSERS = 395;
    }
}
