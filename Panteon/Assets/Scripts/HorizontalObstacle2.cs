using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle2 : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    void Start()
    {
        target = wayPoints2.points[0];
    }


    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoints();
        }
    }

    void GetNextWayPoints()
    {
        if (wavepointIndex >= wayPoints2.points.Length - 1)
        {
            wavepointIndex--;
            target = wayPoints2.points[wavepointIndex];
            return;
        }
        wavepointIndex++;
        target = wayPoints2.points[wavepointIndex];

    }
}
