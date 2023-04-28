using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject gameObjectToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.gameObjectToFollow.transform.position;

        if(MasterData.shouldFollowRotation == true)
        {
            this.transform.rotation = this.gameObjectToFollow.transform.rotation;
        }
        
    }
}
