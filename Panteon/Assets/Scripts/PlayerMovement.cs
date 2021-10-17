using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver = false;
    public float jumpForce = 15f;
    private float rotatorForce = 15.0f; 
    public Rigidbody playerRb;
    public GameObject paintPlane;
    public float moveSpeed = 15.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    private Animator playerAnim;
    public TextMeshProUGUI birandTime;
    public float timeCollapse;
   
    void Start()
    {
        timeCollapse = 0.0f ;
        birandTime.text = "BiRAND " + timeCollapse;
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalMove();
        JumpKey();
        restartGame();

        timeCollapse += Time.deltaTime;
        birandTime.text = "BİRAND " + timeCollapse.ToString("F1");
    }

    private void HorizontalMove()
    {
        if(gameOver==false)
        {
            float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
            transform.Translate(new Vector3(horizontalMove, 0, -0) * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    
        }
    private void JumpKey()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround==true && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
           

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          
            isOnGround = true;

        }
       else if (collision.gameObject.CompareTag("Rotator"))
        {

            playerRb.AddForce(Vector3.left * rotatorForce, ForceMode.VelocityChange);

        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Rotator"))
        {
            gameOver = false;
            transform.position = new Vector3(0, 0, 6);
            timeCollapse = 0.0f ;
            birandTime.text = "BİRAND " + timeCollapse.ToString("F1");
        }
        else if(collision.gameObject.CompareTag("FinishLine"))
        {
            gameOver = true;
            collision.gameObject.SetActive(false);
            paintPlane.gameObject.SetActive(true);
            playerAnim.SetFloat("Speed_f", 0.20f);
            birandTime.text = "BİRAND " + timeCollapse.ToString("F1");
           
        }
       
    }
   
   

    private void restartGame()
    {
        if(transform.position.y<-5.0f)
        {
            transform.position = new Vector3(0, 0, 6);
        }
    }

   
   

}
