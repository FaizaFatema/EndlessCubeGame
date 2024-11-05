using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GroundManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;

    public Transform player;

    public float spawnDistance = 50f;
    public float spawnHeight = 1f;
    public float deleteDistance = 150f;

    private Vector3 lastSpawnPosition;

   private List<GameObject> groundList=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       // lastSpawnPosition = player.position;
    }

    void Update()
    {
        if (player.position.z > lastSpawnPosition.z + spawnDistance)
        {
           SpawnPlatform();
        }
      DeleteOldGrounds();
    }
  
    public void SpawnPlatform()
    {

        GameObject plateForm = groundPrefabs[UnityEngine.Random.Range(0, groundPrefabs.Length)];


        Vector3 prefabSize = plateForm.GetComponent<Renderer>().bounds.size;
      //  Debug.Log($" ground prefab size z is {prefabSize.z}");

        // Calculate the spawn position based on the last position and the size of the last spawned platform
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y + spawnHeight,
            lastSpawnPosition.z + prefabSize.z // Use the z size of the prefab for proper placement
        );

        // Instantiate the new platform
        GameObject newGround= Instantiate(plateForm, spawnPosition, Quaternion.identity);
        groundList.Add(newGround);

        // Update the last spawn position
        lastSpawnPosition = spawnPosition;
    }
    private void DeleteOldGrounds()
    {
        for (int i = groundList.Count - 1; i >= 0; i--)
        {

            // Debug.Log($"Checking platform at {groundList[i]}, player threshold is {player.position.z - deleteDistance}");

            if (groundList[i].transform.position.z < player.position.z - deleteDistance && groundList[i] != null)
            {
                Debug.Log($"DeleteDistance is{deleteDistance} ");
                Destroy(groundList[i]);
                groundList.RemoveAt(i);
            }

        }
    }
}
