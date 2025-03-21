using CTRLInvesting.Client.Options;

namespace CTRLInvesting.Client.Interfaces;
public interface IEmailService
{
    Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
    Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
}