using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    public bool northOn, southOn, eastOn, westOn;

    // Start is called before the first frame update
    void Start()
    {
        //hw answer should be in here!
        MasterData.setupDungeon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
