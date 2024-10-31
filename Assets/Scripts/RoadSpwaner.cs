using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpwaner : MonoBehaviour
{
    public List<GameObject> roads;
    public float offset = 60f;

    // Start is called before the first frame update
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads=roads.OrderBy(r=>r.transform.position.z).ToList();
        }
    }
    public void MoveRoad()
    {
        GameObject moveRoads=roads[0];
        roads.Remove(moveRoads);
        float newZ = roads[roads.Count-1].transform.position.z+offset;
        moveRoads.transform.position = new Vector3(0, 0, newZ);
        roads.Add(moveRoads );
    }
}
