using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObstacle : MonoBehaviour
{
    private float rotY;
    public float rotationSpeed;
    public bool clockwiseRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clockwiseRotation == false)
        {
            rotY += Time.deltaTime * rotationSpeed;


        }
        else
        {
            rotY += Time.deltaTime * rotationSpeed;

        }
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
