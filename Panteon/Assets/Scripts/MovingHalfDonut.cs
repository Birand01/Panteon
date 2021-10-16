using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHalfDonut : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    private bool stickMovement = true;
    private Vector3 startingPosition;
    private float stickZrange1 = 215.0f;
  

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(player.GetComponent<PlayerMovement>().transform.position.z>= stickZrange1)
        {
            stickMovement = true;
            StartCoroutine(StickCo());
            Vector3 v = startingPosition;
            v.x = distanceToCover * Mathf.Sin((Time.time * speed)) + 12.0f;
            transform.position = v;
        }
            
       
       
    }
     public IEnumerator StickCo()
    {
        yield return new WaitForSeconds(4.0f);
        stickMovement = false;
    }
}
