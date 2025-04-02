using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public static SpawnerScript instance;
    [SerializeField] public GameObject entity;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SpawnEntity()
    {
        var gameobject = GameObject.Instantiate(entity, this.transform.position, new Quaternion(0, 1, 0, 1));
        var enemy = gameobject.GetComponent<PatrolBehavior>();
        if (enemy != null ) 
        {
            var waypoints = GetComponent<SpawnerWaypoints>();
            enemy.SetWaypoints(waypoints.Waypoint1, waypoints.Waypoint2);
        }
    }
}
