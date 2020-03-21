namespace SmtpProtocol.Properties.client
{
    /// <summary>
    /// Сlass Client defines the abstract user of our email.
    /// <remarks> User-sender of our email described only by class Client сan not have ways to authorize account, so
    /// we can use this class only for description user-receiver </remarks> </summary>
    public class Client
    {
        
        /// <value> client full username : username@server_domain_name <example> kra@kris.kri  </example> </value> 
        private readonly string _email;
       
        /// <value> display user name <example> Dr.Kra </example></value>
        private readonly string _name;

        /// <summary>
        /// Empty Constructor...useless. Initializing value = ""  
        /// </summary>
        public Client()
        {
            _email = ""; 
            _name = "" ;
        }

        /// <summary>
        /// Main Constructor.
        /// </summary>
        /// <param name="email"> user full username
        /// init. value in format : username@server_domain_name <example> kra@kris.kri  </example> </param>
        /// <param name="name">  display user name init. value <example> Dr.Kra </example> </param>
        public Client(string email, string name)
        {
            _email = email;
            _name = name; 
        }

        /// <summary>
        /// Optional Constructor
        /// </summary>
        /// <param name="email"> user full username
        /// init. value in format : username@server_domain_name <example> kra@kris.kri  </example> </param>
        public Client(string email)
        {
            _email = email; 
        }

        public string GetEmail()
        {
            return _email; 
        }

        public string GetName()
        {
            return _name; 
        }
    }
}