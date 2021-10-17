using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Opponent : MonoBehaviour
{
    public float speed = 10.0f;
    private Transform target;
    private int wavepointIndex = 0;
    private bool gameOver = false;
    private bool isOnGround = true;
    public TextMeshProUGUI senolTime;
    public float timeCollapse;
    void Start()
    {
       timeCollapse= 0.0f;
        senolTime.text = "ŞENOL " + timeCollapse;
        target = OpponentWayPoints.points[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime);

        if(Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            GetNextWayPoint();
        }
        restartGame();

        timeCollapse += Time.deltaTime;
        senolTime.text = "ŞENOL " + timeCollapse.ToString("F1");
    }

    void GetNextWayPoint()
    {
        if(wavepointIndex>=OpponentWayPoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = OpponentWayPoints.points[wavepointIndex];
    }

    private void restartGame()
    {
        if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(0, 0, 0);
            timeCollapse = 0;
            senolTime.text = "ŞENOL " + timeCollapse.ToString("F1");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }
       
        else if (collision.gameObject.CompareTag("Obstacle") )
        {
            gameOver = false;
            transform.position = new Vector3(0, 0, 0);
            timeCollapse = 0;
            senolTime.text = "ŞENOL " + timeCollapse.ToString("F1");

        }
        else if (collision.gameObject.CompareTag("FinishLine"))
        {

            senolTime.text = "ŞENOL " + timeCollapse.ToString("F1");
            gameOver = true;

        }

    }
}
