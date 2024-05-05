using System.Net;
using System.Net.Mail;
using System.Text;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Client.Options;
using CTRLInvesting.Model.Configs;
using Microsoft.Extensions.Options;

namespace CTRLInvesting.Client.Services;
public class EmailService : IEmailService
{
#if DEBUG
    private const string _templatePath = @"EmailTemplate/{0}.html";
#else
    private const string _templatePath = @"/app/publish/wwwroot/EmailTemplate/{0}.html";
#endif
    private readonly SMTPConfigModel _smtpConfig;
    public EmailService(IOptions<SMTPConfigModel> smtpConfig)
    {
        _smtpConfig = smtpConfig.Value;
    }
    private async Task SendEmailAsync(UserEmailOptions userEmailOptions)
    {
        MailMessage mail = new MailMessage
        {
            Subject = userEmailOptions.Subject,
            Body = userEmailOptions.Body,
            From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
            IsBodyHtml = _smtpConfig.IsBodyHTML
        };
        foreach (var toEmail in userEmailOptions.ToEmails)
        {
            mail.To.Add(toEmail);
        }

        NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
        SmtpClient smtpClient = new SmtpClient
        {
            Host = _smtpConfig.Host,
            Port = _smtpConfig.Port,
            EnableSsl = _smtpConfig.EnableSSL,
            UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
            Credentials = networkCredential
        };
        mail.BodyEncoding = Encoding.Default;
        await smtpClient.SendMailAsync(mail);
    }

    public string GetEmailBody(string templateName)
    {
        return File.ReadAllText(string.Format(_templatePath, templateName));        
    }

    public Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions)
    {
        throw new NotImplementedException();
    }

    public async Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions)
    {
        userEmailOptions.Subject = UpdatePlaceHolders("Resetar senha - DiviCheck", userEmailOptions.PlaceHolders);

        userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("ForgotPassword"), userEmailOptions.PlaceHolders);

        await SendEmailAsync(userEmailOptions);
    }

    private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
    {
        if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
        {
            foreach (var placeholder in keyValuePairs)
            {
                if (text.Contains(placeholder.Key))
                {
                    text = text.Replace(placeholder.Key, placeholder.Value);
                }
            }
        }

        return text;
    }
}