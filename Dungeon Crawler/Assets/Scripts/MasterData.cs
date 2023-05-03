using UnityEngine;

public class MasterData
{
    public static bool canGetIntoFight = true;
    public static bool playerShouldAttack = false;
    public static bool monsterShouldAttack = false;
    public static bool shouldFollowRotation = false;
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player thePlayer = null;
    public static GameObject musicLooper = null;

    public static void setupDungeon()
    {
        if(MasterData.isDungeonSetup == false)
        {
            MasterData.cs = new Dungeon(100);
            MasterData.cs.populateCSDepartment();

            MasterData.thePlayer = new Player("Mike");
            MasterData.cs.addPlayer(thePlayer);
            MasterData.isDungeonSetup = true;
        }
    }
 
}
