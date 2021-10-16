using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    void Start()
    {
        target = wayPoints.points[0];
    }

   
    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            GetNextWayPoints();
        }
    }

    void GetNextWayPoints()
    {
        if(wavepointIndex>=wayPoints.points.Length-1)
        {
            wavepointIndex--; 
            target = wayPoints.points[wavepointIndex];
            return;
        }
       wavepointIndex++;
        target = wayPoints.points[wavepointIndex];

    }
}
