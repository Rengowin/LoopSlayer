using NUnit.Framework; 
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    [SerializeField]
    List<GameObject> waypoints;

    float movementSpeed;
    int nextWayPointID = 0;
    Vector3 nextWayPoint;
    Vector3 currentPosition;

    Vector3 directionTowardsWaypoint;
    float distance;

    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        movementSpeed = player.Speed;
    }

    void Update()
    {
        currentPosition = transform.position;
        if (Vector3.Distance(currentPosition, waypoints[nextWayPointID].transform.position)<0.1)
        {
            nextWayPointID++;
            CheckWhereTomoveTo();
        }
        else
        {
            directionTowardsWaypoint = waypoints[nextWayPointID].transform.position - currentPosition;
            distance = Vector3.Distance(currentPosition, nextWayPoint);
            transform.position += Vector3.ClampMagnitude(directionTowardsWaypoint.normalized * movementSpeed*Time.deltaTime, distance);
        }

        movementSpeed = player.Speed;
    }
    
    private void CheckWhereTomoveTo()
    {
        if (nextWayPointID < waypoints.Count)
        {
            nextWayPoint = waypoints[nextWayPointID].transform.position;
        }
        else
        {
            nextWayPointID = 0;
            nextWayPoint = waypoints[nextWayPointID].transform.position;
        }

    }

}
