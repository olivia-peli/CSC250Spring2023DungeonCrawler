using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    private void Awake()
    {
        if(MasterData.musicLooper == null)
        {
            MasterData.musicLooper = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
