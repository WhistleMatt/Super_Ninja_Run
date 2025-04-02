using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] private Transform waypoint1;
    [SerializeField] private Transform waypoint2;
    private Transform targetWaypoint;
    public Transform StartingPosition;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetWaypoint);
        MoveEntity();
        distance = Vector3.Distance(waypoint1.position, transform.position);
        if (Vector3.Distance(waypoint1.position, transform.position) < 0.1f)
        {
            targetWaypoint = waypoint2;
        }
        else if (Vector3.Distance(waypoint2.position, transform.position) < 0.1f)
        {
            targetWaypoint = waypoint1;
        }

    }

    void MoveEntity()
    {
        var movement = targetWaypoint.position - transform.position;
        movement.Normalize();
        movement *= Time.deltaTime;
        transform.position += movement;
    }

    public void SetWaypoints(Transform _waypoint1, Transform _waypoint2)
    {
        waypoint1 = _waypoint1;
        waypoint2 = _waypoint2;
        targetWaypoint = waypoint1;
    }
}
