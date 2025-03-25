# Old code with side effects
# user_session = {
#     'is_logged_in': True,
#     'token': 'abc123'
# }
# def logout():
#     user_session['is_logged_in'] = False
#     user_session['token'] = None
#     print("User logged out.")

# New code without side effects
def logout(session):
    new_session = session.copy()
    new_session['is_logged_in'] = False
    new_session['token'] = None
    print("User logged out.")
    return new_session

user_session = {'is_logged_in': True, 'token': 'abc123'}
user_session = logout(user_session)