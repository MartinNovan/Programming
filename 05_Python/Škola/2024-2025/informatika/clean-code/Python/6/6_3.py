from datetime import datetime

def send_email(to, subject, body):
    email = {
        'to': to,
        'subject': subject,
        'body': body,
        'sent_at': datetime.now(),
        'status': 'sent'
    }
    log_email(email)
    return email

welcome_email = send_email("newuser@example.com", "Welcome!", "Thank you for joining.")
welcome_email['is_welcome_email'] = True
log_email(welcome_email)

password_reset_email = send_email("user@example.com", "Reset Password", "Click here to reset your password.")
password_reset_email['is_password_reset'] = True
log_email(password_reset_email)
