using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildingPrefabs;

    public Transform player;

    public float spawnDistance = 15f;
    public float spawnHeight = 1f;

    private Vector3 lastSpawnPosition;

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
        Building building = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)].GetComponent<Building>();

        Vector3 spwanPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, lastSpawnPosition.z + 0);
        
        Building spawnedBuilding = Instantiate(building, spwanPosition, Quaternion.identity).GetComponent<Building>();
        spawnedBuilding.transform.position = new Vector3(spawnedBuilding.transform.position.x, spawnedBuilding.transform.position.y, lastSpawnPosition.z + spawnedBuilding.Length);
        Debug.Log($"building size z is {spawnedBuilding.Length}");
        spwanPosition.z = lastSpawnPosition.z + (spawnedBuilding.Length);
        lastSpawnPosition = spwanPosition;
    }
}
