using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//BURAYA BAKARLAR
public class Opponent3 : MonoBehaviour
{
    private Transform target;
    public float speed = 10.0f;
    private int wavepointIndex = 0;
    private bool gameOver = false;
    private bool isOnGround = true;
    public TextMeshProUGUI birolTime;
    private Vector3 distanceTravelZ;
    void Start()
    {
        birolTime.text = "BİROL " + distanceTravelZ.z;
        target = wayPoints3.points[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        restartGame();
        distanceTravelZ.z += transform.position.z;
        birolTime.text = "BİROL " + distanceTravelZ.z.ToString("0");
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= wayPoints3.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = wayPoints3.points[wavepointIndex];
    }


    private void restartGame()
    {
        if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(-10, 0, 5);
           
        }
        distanceTravelZ.z = 0;
        birolTime.text = "BİROL " + distanceTravelZ.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = false;
            transform.position = new Vector3(-10, 0, 5);
            distanceTravelZ.z = 0;
            birolTime.text = "BİROL " + distanceTravelZ.z;


        }
        else if (collision.gameObject.CompareTag("FinishLine"))
        {


            gameOver = true;

        }

    }
}
