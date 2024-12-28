using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager Instance{get;private set;}


    public Transform player;

    public float spawnDistance = 15f;
    public float spawnHeight = 1f;

    public string groundTag = "Ground";

    private Vector3 lastSpawnPosition;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
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
        GameObject plateForm = ObjectPool.Instance.SpawnFromPool(groundTag,Vector3.zero,Quaternion.identity);
        Vector3 prefabSize = plateForm.GetComponent<Renderer>().bounds.size;
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y + spawnHeight,
            lastSpawnPosition.z + prefabSize.z // Use the z size of the prefab for proper placement
        );
        plateForm.transform.position = spawnPosition;


        // Get the size of the selected prefab
       // Debug.Log($" ground prefab size z is {prefabSize.z}");
        // Calculate the spawn position based on the last position and the size of the last spawned platform


        // Instantiate the new platform
     //   Instantiate(plateForm, spawnPosition, Quaternion.identity);

        // Update the last spawn position
        lastSpawnPosition = spawnPosition;
    }
}
