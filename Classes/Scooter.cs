using System;

public class Scooter
{
    //nextSerial is static ie belongs to the class itself rather than instances of the class. 
    //Static members are shared across all instances of the class. Therefore, nextSerial keeps
    //track of the serial number across all Scooter instances, which is why it is static.
    //static fields (like nextSerial are initialised once, when the class is first loaded- whereas the other properties are initialised each time a new instance is created)
    //as nextSerial assigns unique serial numbers sequentially across all scooters it needs to be a single shared counter, making it static
    private static int nextSerial = 1;

    //properties of the Scooter class (getters and setters/ fields and properties)
    public string Station { get; set; }         //set outside of class (in ScooterApp) so set cannot be private
    public User username { get; private set; }  //User (the object), followed by User (the property)    //reference User instance as username
    public int Serial { get; private set; }
    public int Charge { get; private set; }
    public bool isBroken { get; private set; }

    //constructor to initialise a new Scooter with default values.
    //constructor one parameter = station. Initialises all other properties too 
    public Scooter(string station)
    {
        Station = station;
        username = new("", "", 19); 
        Serial = nextSerial++;
        Charge = 100;
        isBroken = false;
    }

    // Methods
    //void as does not return a value 
    public void rent(User user)
    {
        if (Charge <= 20)
        {
            throw new InvalidOperationException("scooter needs to charge");
        }
        if (isBroken == true)
        {
            throw new InvalidOperationException("scooter needs repair");
        }
        //If all conditions are met, assign the scooter to the user.
        Station = "";
        //user.username = username;
        username = user;
    }

    public void dock(string station)
    {
        //method needs to set station to station and clear user 
        Station = station;
    }
}