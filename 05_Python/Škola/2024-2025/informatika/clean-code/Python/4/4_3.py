user_session = {
    'is_logged_in': True,
    'token': 'abc123'
}

def logout():
    user_session['is_logged_in'] = False
    user_session['token'] = None
    print("User logged out.")

logout()
