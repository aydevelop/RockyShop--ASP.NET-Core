using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }


    //namespace Rocky.Utility
    //{
    //    public class EmailSender : IEmailSender
    //    {
    //        private readonly IConfiguration _configuration;

    //        public MailJetSettings _mailJetSettings { get; set; }

    //        public EmailSender(IConfiguration configuration)
    //        {
    //            _configuration = configuration;
    //        }

    //        public Task SendEmailAsync(string email, string subject, string htmlMessage)
    //        {
    //            return Execute(email, subject, htmlMessage);
    //        }

    //        public async Task Execute(string email, string subject, string body)
    //        {
    //            _mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

    //            MailjetClient client = new MailjetClient(_mailJetSettings.ApiKey, _mailJetSettings.SecretKey)
    //            {
    //                Version = ApiVersion.V3_1,
    //            };
    //            MailjetRequest request = new MailjetRequest
    //            {
    //                Resource = Send.Resource,
    //            }
    //             .Property(Send.Messages, new JArray {
    // new JObject {
    //  {
    //   "From",
    //   new JObject {
    //    {"Email", "dotnetmastery@protonmail.com"},
    //    {"Name", "Ben"}
    //   }
    //  }, {
    //   "To",
    //   new JArray {
    //    new JObject {
    //     {
    //      "Email",
    //      email
    //     }, {
    //      "Name",
    //      "DotNetMastery"
    //     }
    //    }
    //   }
    //  }, {
    //   "Subject",
    //   subject
    //  }, {
    //   "HTMLPart",
    //   body
    //  }
    // }
    //             });
    //            await client.PostAsync(request);
    //        }
    //    }
    //}

}
