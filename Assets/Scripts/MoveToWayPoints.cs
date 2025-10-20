using NUnit.Framework; 
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    [SerializeField]
    List<GameObject> waypoints;


    public float movementSpeed;
    //private int currentWayPointID = 0; //not used yet and may be never :D
    private int nextWayPointID = 0;
    private Vector3 nextWayPoint;
    private Vector3 currentPosition;

    private Vector3 directionTowardsWaypoint;
    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
    
    private void CheckWhereTomoveTo()
    {
        Debug.Log("we opend the check where to move");
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
