using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Email
{
	public class SmtpEmailSender : IEmailSender
	{
		private string host;
		private int port;
		private string from;
		private string password;

		public SmtpEmailSender(string host, int port, string from, string password)
		{
			this.host = host;
			this.port = port;
			this.from = from;
			this.password = password;
		}

		public string ToEmail { get; set; }
		public string Body { get; set; }
		public string Subject { get; set; }

		public void Send()
		{
			var smtp = new SmtpClient
			{
				Host = host,
				Port = port,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				Credentials = new NetworkCredential(from, password)
			};
			using (var message = new MailMessage(from, ToEmail)
			{
				Subject = Subject,
				Body = Body
			})
			{
				smtp.Send(message);
			}
		}
	}
}

