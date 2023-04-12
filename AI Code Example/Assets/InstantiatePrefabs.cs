using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject roomPrefab;   // The prefab for a room
    public int dungeonSize = 100;   // The number of rooms to generate
    public float roomSize = 10f;    // The size of each room

    void Start()
    {
        // Create a list to store the rooms
        List<GameObject> rooms = new List<GameObject>();

        // Create the first room at the origin
        GameObject firstRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity);
        rooms.Add(firstRoom);

        // Generate the remaining rooms
        for (int i = 1; i < dungeonSize; i++)
        {
            // Choose a random room from the list of existing rooms
            GameObject parentRoom = rooms[Random.Range(0, rooms.Count)];

            // Calculate a random position for the new room
            Vector3 newPosition = parentRoom.transform.position + new Vector3(Random.Range(-roomSize, roomSize), 0, Random.Range(-roomSize, roomSize));

            // Check if the new position overlaps with any existing rooms
            bool overlap = false;
            foreach (GameObject room in rooms)
            {
                if (Vector3.Distance(newPosition, room.transform.position) < roomSize)
                {
                    overlap = true;
                    break;
                }
            }

            // If the new position does not overlap with any existing rooms, instantiate the new room
            if (!overlap)
            {
                GameObject newRoom = Instantiate(roomPrefab, newPosition, Quaternion.identity);

                // Add the new room to the list of existing rooms
                rooms.Add(newRoom);
            }
            // If the new position overlaps with an existing room, try again with a different parent room
            else
            {
                i--;
            }
        }
    }
}
