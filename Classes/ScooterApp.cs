using System;
using static Scooter;
using static User; 

public class ScooterApp
{
    //properties of the ScooterApp class (getters and setters/ fields and properties) 
    //stations: An object whose keys are the names of station locations, and whose values are arrays of Scooters.
    //You can hard-code these stations in the constructor. There should be at least three. Initially, there are no scooters at any stations.
    //key value pairs: firstly declare a Dictionary. IDictionary<int, string> d = new Dictionary<int, string>(); Now, add elements with KeyValuePair. 
    //Inheritance Object >> ValueType >> KeyValuePair<TKey, TValue>

    

    //properties
    private Dictionary<string, List<Scooter>> stations;
    private Dictionary<string, User> registeredUsers; 

    //constructor 
    public ScooterApp()
    {
        //constructor - making within the constructor(empty parameter) 
        //?need to be able to set null values. Dictionary<string, List <Scooter> > stations = new Dictionary <string, List<Scooter>> ();
        stations = new Dictionary<string, List<Scooter>>();
        stations.Add("Station1", new List<Scooter>());
        stations.Add("Station2", new List<Scooter>());
        stations.Add("Station3", new List<Scooter>());

        //imports the class user (and filled in values of the constructor)
        registeredUsers = new Dictionary<string, User>();
        registeredUsers.Add("personUsername", new User("personUsername", "insertPassword", 18));
        Console.WriteLine(registeredUsers.ToString());
    }

    //Methods 
    public void registerUser(string username, string password, int age)
    {
        if (registeredUsers.ContainsKey(username))
        {
            throw new InvalidOperationException("user has been registered");
        }
        else if (age < 18)
        {
            throw new InvalidOperationException("too young to register");
        }
        //If all conditions are met, assign register user.
        //create new user object using the class 
        User newUser = new User (username, password, age ) ;
        //assign that user to registeredusers
        registeredUsers[username] = newUser ;
    }

    public void loginUser(string username, string password)
    {
        //check if user exists 
        if (!registeredUsers.ContainsKey(username))
        {
            throw new InvalidOperationException("Username or password is incorrect");
        }
        else
        {
            //attempt to log user in 
            //making an instance of the user class to use user class methods
            //instance of User is called user 
            User user = registeredUsers[username];
            user.login(password);
            Console.WriteLine("user has been logged in");
        }
    }

    public void logoutUser(string username)
    {
        if (!registeredUsers.ContainsKey(username))
        {
            throw new InvalidOperationException("no such user is logged in");
        }
        else
        {
            User user = registeredUsers[username];
            user.logout();
            Console.WriteLine("user is logged out");
        }
    }

    //station variable being passed in is the station name/ instance 
    public void createScooter( string station)
    {
        if (!stations.ContainsKey(station))
        {
            throw new InvalidOperationException("no such station error");
        }
        Scooter newScooter = new Scooter(station);
        stations[station].Add(newScooter);
    }

    public void dockScooter(Scooter scooter, string station)
    {
        if (!stations.ContainsKey(station))
        {
            throw new InvalidOperationException("no such station");
        }
        else if (scooter.Station != "")
        {
            throw new InvalidOperationException("scooter already at station");
        }
        else
        {
            List<Scooter> scootersAtStation = stations[station];
            scootersAtStation.Add(scooter);
            Console.WriteLine("scooter is docked");
        }
    }

    public void rentScooter(Scooter scooter, User user)
    {
        if (scooter.Station == "")
        {
            Console.WriteLine("scooter already rented");
        }
        else
        {
            //bool removedScooter = Station.Remove(scooter);
            //in stations array/ dictionary, selecting the scooter instances Station associated in Scooter class 
            //selecting the scooters station then remove instance of scooter, removed from scooter dictoionary  
            stations[scooter.Station].Remove(scooter);
            scooter.Station = ""; 
            Console.WriteLine("scooter is ready to rent");
        }

    }











}
//stations: An object whose keys are the names of station locations, and whose values are arrays of Scooters.
//You can hard-code these stations in the constructor. There should be at least three. Initially, there are no scooters
//at any stations.registeredUsers: An object whose keys are usernames to store all users