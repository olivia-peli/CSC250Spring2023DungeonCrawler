using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    public bool enableFights = true;
    public float chanceToGetIntoFight = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.enableFights)
        {
            int chanceToFight = Random.Range(1, 100);

            if (chanceToFight <= this.chanceToGetIntoFight)
            {
                //print("Start a Fight");

                //turn off music
                Destroy(MasterData.musicLooper);
                MasterData.musicLooper = null;

                SceneManager.LoadScene("FightScene");
            }
            else
            {
                print("No monsters found!");
            }
        }
        
    }
}
