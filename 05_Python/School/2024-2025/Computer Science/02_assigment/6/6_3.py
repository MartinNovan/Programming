# Old code with repetition
# welcome_email = send_email("newuser@example.com", "Welcome!", "Thank you for joining.")
# welcome_email['is_welcome_email'] = True
# log_email(welcome_email)

# password_reset_email = send_email("user@example.com", "Reset Password", "Click here to reset your password.")
# password_reset_email['is_password_reset'] = True
# log_email(password_reset_email)

# New code without repetition
def send_and_log_email(to, subject, body, email_type):
    email = send_email(to, subject, body)
    email[email_type] = True
    log_email(email)
    return email

welcome_email = send_and_log_email("newuser@example.com", "Welcome!", "Thank you for joining.", 'is_welcome_email')
password_reset_email = send_and_log_email("user@example.com", "Reset Password", "Click here to reset your password.", 'is_password_reset')