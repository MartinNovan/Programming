class UserSession
{
    public bool IsLoggedIn { get; set; } = true;
    public string Token { get; set; } = "abc123";
}

UserSession userSession = new UserSession();

UserSession Logout(UserSession currentSession)
{
    var newSession = new UserSession
    {
        IsLoggedIn = false,
        Token = null
    };
    Console.WriteLine("User logged out.");
    return newSession;
}

userSession = Logout(userSession);
