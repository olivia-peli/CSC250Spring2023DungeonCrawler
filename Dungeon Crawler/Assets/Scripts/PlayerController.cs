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
        
     
    }

    private void updateExits()
    {
        Room currentRoom = MasterData.p.getCurrentRoom();
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
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
            //this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Exit") && MasterData.isExiting)
        {
            if(other.gameObject == this.northExit)
            {
                MasterData.whereDidIComeFrom = "north";
            }
            else if (other.gameObject == this.southExit)
            {
                MasterData.whereDidIComeFrom = "south";
            }
            else if (other.gameObject == this.eastExit)
            {
                MasterData.whereDidIComeFrom = "east";
            }
            else if (other.gameObject == this.westExit)
            {
                MasterData.whereDidIComeFrom = "west";
            }
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
        Room currentRoom = MasterData.p.getCurrentRoom();

        if (Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("north"))
            {
                currentRoom.takeExit(MasterData.p, "north");
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("west"))
            {
                currentRoom.takeExit(MasterData.p, "west");
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("east"))
            {
                currentRoom.takeExit(MasterData.p, "east");
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("south"))
            {
                currentRoom.takeExit(MasterData.p, "south");
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }

    }
}
