using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfPrefabs = 100;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float prefabSize = 1f;
    public float wallHeight = 10f;
    public float wallThickness = 1f;
    public float doorWidth = 2f;
    public float doorHeight = 6f;

    private void Start()
    {
        // Create the walls
        CreateWall(new Vector3(minX, wallHeight / 2f, 0), new Vector3(wallThickness, wallHeight, maxZ));
        CreateWall(new Vector3(maxX, wallHeight / 2f, 0), new Vector3(wallThickness, wallHeight, maxZ));
        CreateWall(new Vector3(0, wallHeight / 2f, minZ), new Vector3(maxX - minX - wallThickness, wallHeight, wallThickness));
        CreateWall(new Vector3(0, wallHeight / 2f, maxZ), new Vector3(maxX - minX - wallThickness, wallHeight, wallThickness));

        // Create the prefabs
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector3 position = GetRandomPosition();
            GameObject newPrefab = Instantiate(prefab, position, Quaternion.identity);

            // Check for collisions with existing prefabs
            Collider[] colliders = Physics.OverlapBox(position, Vector3.one * prefabSize / 2f);
            foreach (Collider collider in colliders)
            {
                if (collider != newPrefab.GetComponent<Collider>())
                {
                    Destroy(newPrefab);
                    break;
                }
            }
        }

        // Create the doors
        CreateDoor(new Vector3(minX + doorWidth / 2f, doorHeight / 2f, 0), new Vector3(doorWidth, doorHeight, wallThickness));
        CreateDoor(new Vector3(maxX - doorWidth / 2f, doorHeight / 2f, 0), new Vector3(doorWidth, doorHeight, wallThickness));
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX + prefabSize / 2f, maxX - prefabSize / 2f);
        float z = Random.Range(minZ + prefabSize / 2f, maxZ - prefabSize / 2f);
        return new Vector3(x, prefabSize / 2f, z);
    }

    private void CreateWall(Vector3 position, Vector3 size)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = position;
        wall.transform.localScale = size;
        wall.GetComponent<Renderer>().material.color = Color.gray;
        wall.AddComponent<BoxCollider>();
    }

    private void CreateDoor(Vector3 position, Vector3 size)
    {
        GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
        door.transform.position = position;
        door.transform.localScale = size;
        door.GetComponent<Renderer>().material.color = Color.gray;
        door.AddComponent<BoxCollider>();
        door.AddComponent<DoorScript>();
    }
}

public class DoorScript : MonoBehaviour
{
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isOpen)
            {
                transform.position += Vector3.up * 2f;
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                transform.position -= Vector3.up * 2f;
                isOpen = false;
            }
        }
    }
}
