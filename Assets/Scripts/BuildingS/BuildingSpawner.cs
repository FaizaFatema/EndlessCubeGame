using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
   public static BuildingSpawner Instance{get;private set;}

    public Transform player;

    public float spawnDistance = 15f;
    public float spawnHeight = 1f;

    public string buildingTag = "Building";

    private Vector3 lastSpawnPosition;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > lastSpawnPosition.z + spawnDistance)
        {
            SpwanPlatform();
        }
    }
    public void SpwanPlatform()
    {
        GameObject building = BuildingObjectPool.Instance.SpawnFromPool(buildingTag, Vector3.zero, Quaternion.identity);
        Building buildingScript = building.GetComponent<Building>();
        Vector3 spwanPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, lastSpawnPosition.z + buildingScript.Length);
        building.transform.position = spwanPosition;

      //Building spawnedBuilding = Instantiate(building, spwanPosition, Quaternion.identity).GetComponent<Building>();
      // spawnedBuilding.transform.position = new Vector3(spawnedBuilding.transform.position.x, spawnedBuilding.transform.position.y, lastSpawnPosition.z + spawnedBuilding.Length);
      //  Debug.Log($"building size z is {spawnedBuilding.Length}");
      // spwanPosition.z = lastSpawnPosition.z + (spawnedBuilding.Length);
        lastSpawnPosition = spwanPosition;
    }
}
