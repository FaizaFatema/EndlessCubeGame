using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform player;
    public float spawnDistance = 15f;
    public float spawnHeight = 1f;

    private Vector3 lastSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPosition = player.position;
    }

    void Update()
    {
        if (player.position.z > lastSpawnPosition.z + spawnDistance)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        // Select a random ground prefab
        GameObject plateForm = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        // Get the size of the selected prefab
        Vector3 prefabSize = plateForm.GetComponent<Renderer>().bounds.size;
        Debug.Log($" ground prefab size z is {prefabSize.z}");

        // Calculate the spawn position based on the last position and the size of the last spawned platform
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y + spawnHeight,
            lastSpawnPosition.z + prefabSize.z // Use the z size of the prefab for proper placement
        );

        // Instantiate the new platform
        Instantiate(plateForm, spawnPosition, Quaternion.identity);

        // Update the last spawn position
        lastSpawnPosition = spawnPosition;
    }
}
