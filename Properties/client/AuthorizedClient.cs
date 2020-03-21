namespace SmtpProtocol.Properties.client
{
    /// <summary> Class AuthorizedClient.
    /// <remarks> This class can be used for description user-sender of our email. </remarks> </summary>
    public class AuthorizedClient : Client
    {
        /// <value> user password from email </value>
        private readonly string _password;
   
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="email"> user full username
        /// init. value in format : username@server_domain_name <example> kra@kris.kri  </example> </param>
        /// <param name="name">  display user name init. value <example> Dr.Kra </example> </param>
        /// <param name="password"> user password from email </param>
        public AuthorizedClient(string email, string name, string password)
            : base(email, name)
        {
            _password = password; 
        }
        
        /// <summary> Constructor without _name argument. _name will be initialized standard value "".
        /// <remarks> This constructor call parent constructor {A}, witch is selected depending on the
        /// arguments in <code> : base ( arguments ); </code> </remarks> </summary>
        /// <param name="email"> user full username
        /// init. value in format : username@server_domain_name <example> kra@kris.kri  </example> </param>
        /// <param name="password"> user password from email </param>
        public AuthorizedClient(string email, string password)
            : base(email)
        {
            _password = password;
        }

        public string GetPassword()
        {
            return _password; 
        }
        
    }
}