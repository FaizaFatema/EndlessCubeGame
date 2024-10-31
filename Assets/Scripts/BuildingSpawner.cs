using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildingPrefabs;

    public Transform player;

    public float spawnDistance = 15f;
    public float spawnRange = 3f;
    public float spawnHeight = 1f;

    private Vector3 lastSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPosition=player.position;
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
        GameObject plateform = buildingPrefabs[Random.Range(0,buildingPrefabs.Length)];
        Vector3 prefabSize=plateform.GetComponent<Renderer>().bounds.size;
        Vector3 spwanPosition = new Vector3(transform.position.x,transform.position.y+spawnHeight,lastSpawnPosition.z+prefabSize.z);
        Instantiate(plateform,spwanPosition,Quaternion.identity);
        lastSpawnPosition=spwanPosition;
    }
}
