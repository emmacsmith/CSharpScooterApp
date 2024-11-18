using System;

public class User
{
    //properties of the User class fields and properties
    public string Username { get; set; }
    private string Password;                    //private for secutiry 
    public int Age { get; set; }
    public bool LoggedIn { get; set; }

    //constructor to initialise a new instance of the user 
    //loggedIn is not set in the constructor 
    public User(string username, string password, int age)
    {
        Username = username;
        Password = password;
        Age = age;
        LoggedIn = false;
    }

    //Methods 
    public void login(string password)
    {
        if (password == Password)           //check if provided password is the same as the user instance password 
        {
            LoggedIn = true;
        }
        else
        {
            throw new InvalidOperationException("incorrect password");
        }
    }

    public void logout()
    {
        LoggedIn = false;
    }
}

