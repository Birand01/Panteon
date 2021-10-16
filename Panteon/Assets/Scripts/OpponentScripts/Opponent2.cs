using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Opponent2 : MonoBehaviour
{
    public float speed = 10.0f;
    private Transform target;
    
    private int wavepointIndex = 0;
    private bool gameOver = false;
    private bool isOnGround = true;
    public TextMeshProUGUI birandTime;
    private Vector3 distanceTravelZ;
    void Start()
    {
        birandTime.text = "BİRAND " + distanceTravelZ.z;
        target = OpponentWayPoints2.points[0];
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
        birandTime.text = "BİRAND " + distanceTravelZ.z.ToString("0");
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= OpponentWayPoints2.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = OpponentWayPoints2.points[wavepointIndex];
    }

    private void restartGame()
    {
        if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(8, 0, 6);
            distanceTravelZ.z = 0;
            birandTime.text = "BİRAND " + distanceTravelZ.z;
        }
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
            transform.position = new Vector3(8, 0, 6);
            distanceTravelZ.z = 0;
            birandTime.text = "BİRAND " + distanceTravelZ.z;

        }
        else if (collision.gameObject.CompareTag("FinishLine"))
        {


            gameOver = true;

        }

    }
}
