using System;
using System.Net;
using System.Net.Mail;
using SmtpProtocol.Properties.client;
using SmtpProtocol.Properties.server.ports;

namespace SmtpProtocol.Properties.server
{
    public class Server
    {
        
        /// <value> Value of port, used smtp-server. Default value of port = 2525 </value> 
        private readonly int _port;
        /// <value> User-sender. Must have email and password, also optional </value>
        private readonly AuthorizedClient _sender;
        private SmtpClient _smtpSender;
        /// <value> Smtp-server from which server will send. Depends on email of user-receiver,
        /// for example mail.ru port=2525, smtp-server="smtp.mail.ru" </value>
        private string _host = "smtp.";
        
        /// <value> server answer for sending message </value>
        private const string sendMessageSuccessAnswer = "Message was sent successfully";
        private const string SendMessageNotSendAnswer = "Message was not send";

        /// <summary> Main constructor </summary>
        /// <param name="port"> smtp-port, used to send message </param>
        /// <param name="sender"> User-receiver. Must have email, also optional </param>
        public Server(int port, AuthorizedClient sender)
        {
            _port = port;
            _sender = sender;
            
            var tokens = sender.GetEmail().Split('@');
            _host += tokens[tokens.Length - 1]; 
            //Console.WriteLine(_host);
            CreateSmtpClient();
        }
        
        /// <summary> Constructor without port argument. Port will be initialized standard port value.
        /// <remarks> This constructor call previously described constructor {A}, witch is selected depending on the
        /// arguments in <code> : this ( arguments ); </code> </remarks> </summary>
        /// <param name="sender"> User-sender. Must have email and password, also optional </param>
        public Server(AuthorizedClient sender)
            : this(Ports.StandardPort, sender)    
        {
        }
        private void CreateSmtpClient()
        {
            _smtpSender = new SmtpClient(_host, _port)
            {
                UseDefaultCredentials = false,
                // аутентификация данных отправителя
                Credentials = new NetworkCredential(_sender.GetEmail(), _sender.GetPassword()),
                // шифруем сообщение SSL
                EnableSsl = true, 
                // указываем время ответа сервера. Если оно превышено - Exception
                Timeout = 6000
                
            };
        }

        /// <summary> method send message on the mail of receiver.
        /// <remarks> Class MailMessage is message witch we will send</remarks>
        /// <exception cref="Exception"> if something wrong, сatch SmtpException </exception>
        /// </summary>
        /// <param name="receiver"> User-receiver. Must have email, also optional </param>
        /// <param name="text"> text message </param>
        public void SendMessage(Client receiver, string text)
        {
            try
            {

                var to = new MailAddress(receiver.GetEmail(), receiver.GetName());
                var from = new MailAddress(_sender.GetEmail(), _sender.GetName());
                var message = new MailMessage(from, to)
                {
                    Subject = "It's test",
                    Body = text
                };

                _smtpSender.Send(message);
                Console.WriteLine(sendMessageSuccessAnswer);
                
                //Console.WriteLine(String.Join(" ","Mail form:",_sender.GetEmail()));
                //Console.WriteLine(String.Join(" ","Port",_port," Sender ok"));
                //Console.WriteLine(String.Join(" ","RCTP to:",receiver.GetEmail()));
                //Console.WriteLine(String.Join(" ",_port,receiver.GetEmail(),"Recepient OK"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(SendMessageNotSendAnswer);
            }
        }
    }
}
