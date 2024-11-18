using System;

void SendEmail(string to, string subject, string body)
{
    Email email = new Email
    {
        To = to,
        Subject = subject,
        Body = body,
        SentAt = DateTime.Now,
        Status = "sent"
    };
    LogEmail(email);
}

Email welcomeEmail = new Email();
SendEmail("newuser@example.com", "Welcome!", "Thank you for joining.");
welcomeEmail.IsWelcomeEmail = true;
LogEmail(welcomeEmail);

Email passwordResetEmail = new Email();
SendEmail("user@example.com", "Reset Password", "Click here to reset your password.");
passwordResetEmail.IsPasswordReset = true;
LogEmail(passwordResetEmail);
