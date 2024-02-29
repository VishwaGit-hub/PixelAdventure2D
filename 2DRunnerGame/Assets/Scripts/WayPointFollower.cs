using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentwayPointIndex = 0;

    [SerializeField] private float speed = 2f;
   

   
    void Update()
    {
        if (Vector2.Distance(wayPoints[currentwayPointIndex].transform.position,transform.position) <.1f)
        {
            currentwayPointIndex++;
            if(currentwayPointIndex>=wayPoints.Length)
            {
                currentwayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentwayPointIndex].transform.position , Time.deltaTime * speed  );
    }
}
