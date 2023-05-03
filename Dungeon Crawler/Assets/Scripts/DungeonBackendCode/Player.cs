public class Player : Inhabitant
{
    private Room currentRoom;

    public Player(string name) : base(name)
    {
        //this.ac = 1000;
        //this.damage = 1000;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        if (r != null)
        {
            this.currentRoom = r;
        }
    }

    //getter (accessor) for read only access to the private field name
    public string getName()
    {
        return this.name;
    }

}