using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient("a9e153a29582b1510d60d88c2f7b913d", "a0db5c9f8a3e72a8d3a8f2000b07502d")
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
             new JObject {
              {
               "From",
                   new JObject {
                    {"Email", ""},
                    {"Name", "Maria"}
                   }
                  }, {
                   "To",
                   new JArray {
                    new JObject {
                     {
                      "Email",
                      email
                     }, {
                      "Name",
                      "DotNetMastery"
                     }
                    }
                   }
                  }, {
                   "Subject",
                   subject
                  },  {
                   "HTMLPart",
                  body 
                  }
                 }
             });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
