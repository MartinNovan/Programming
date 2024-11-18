let userSession = {
  isLoggedIn: true,
  token: "abc123"
};

function logout() {
  userSession.isLoggedIn = false;
  userSession.token = null;
  console.log("User logged out.");
}

logout();
