using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    public GameObject playerCostume;

    // Start is called before the first frame update
    void Start()
    {
        this.updateExits();

        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if (!MasterData.whereDidIComeFrom.Equals("?"))
        {
            if(MasterData.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.playerCostume.transform.LookAt(this.southExit.transform);

                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.playerCostume.transform.LookAt(this.westExit.transform);

                this.rb.AddForce(Vector3.left * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.playerCostume.transform.LookAt(this.eastExit.transform);

                this.rb.AddForce(Vector3.right * 150.0f);
            }
        }
        StartCoroutine(PlayerHeal());
     
    }

    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(3f);
        MasterData.thePlayer.healHP(1);
        StartCoroutine(PlayerHeal());
    }

    private void updateExits()
    {
        Room currentRoom = MasterData.thePlayer.getCurrentRoom();
        if(currentRoom.hasExit("north") == false)
        {
            this.northExit.SetActive(false);
        }
        if (currentRoom.hasExit("south") == false)
        {
            this.southExit.SetActive(false);
        }
        if (currentRoom.hasExit("east") == false)
        {
            this.eastExit.SetActive(false);
        }
        if (currentRoom.hasExit("west") == false)
        {
            this.westExit.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("center"))
        {
            MasterData.canGetIntoFight = true;
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
            //this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Exit") && MasterData.isExiting)
        {
            MasterData.isExiting = false;
            SceneManager.LoadScene("DungeonRoom");
        }
        else if(other.gameObject.CompareTag("Exit") && !MasterData.isExiting)
        {
            MasterData.isExiting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Room currentRoom = MasterData.thePlayer.getCurrentRoom();

        if (Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("north"))
            {
                currentRoom.takeExit(MasterData.thePlayer, "north");
                MasterData.whereDidIComeFrom = "north";

                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            
            if (currentRoom.hasExit("west"))
            {
                currentRoom.takeExit(MasterData.thePlayer, "west");
                MasterData.whereDidIComeFrom = "west";
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("east"))
            {
                currentRoom.takeExit(MasterData.thePlayer, "east");
                MasterData.whereDidIComeFrom = "east";
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("south"))
            {
                currentRoom.takeExit(MasterData.thePlayer, "south");
                MasterData.whereDidIComeFrom = "south";
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }

    }
}
