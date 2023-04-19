using UnityEngine;

public class MasterData
{
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;
    public static GameObject musicLooper = null;

    public static void setupDungeon()
    {
        if(MasterData.isDungeonSetup == false)
        {
            MasterData.cs = new Dungeon(100);
            MasterData.cs.populateCSDepartment();

            MasterData.p = new Player("Mike");
            MasterData.cs.addPlayer(p);
            MasterData.isDungeonSetup = true;
        }
    }
 
}
