function sendEmail(to, subject, body) {
  let email = {};
  email.to = to;
  email.subject = subject;
  email.body = body;
  email.sentAt = new Date();
  email.status = "sent";
  logEmail(email);
  return email;
}

let welcomeEmail = sendEmail("newuser@example.com", "Welcome!", "Thank you for joining.");
welcomeEmail.isWelcomeEmail = true;
logEmail(welcomeEmail);

let passwordResetEmail = sendEmail("user@example.com", "Reset Password", "Click here to reset your password.");
passwordResetEmail.isPasswordReset = true;
logEmail(passwordResetEmail);
