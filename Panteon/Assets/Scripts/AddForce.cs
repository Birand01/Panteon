using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private float stickForce = 2.0f;
    private PlayerMovement playerMovement;
    private Rigidbody stickRb;
     void Start()
    {
        stickRb = GetComponent<Rigidbody>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
          if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 awayFromStick = (collision.gameObject.transform.position - transform.position);
            playerMovement.playerRb.AddForce(awayFromStick * stickForce, ForceMode.Impulse);



        }
    }
}
