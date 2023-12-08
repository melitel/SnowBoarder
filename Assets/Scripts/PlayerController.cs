using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 20f;    
    Rigidbody2D rb2d = null;
    SurfaceEffector2D surfaceEffector = null;
    [SerializeField] float normalSpeed = 20f;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) 
        {
            rotatePlayer();
            respondToBoost();
        }
    }

    public void disableControls()
    {
        canMove = false;
    }

    void respondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector.speed = normalSpeed *2;
        }
        else 
        {
            surfaceEffector.speed = normalSpeed;
        }
    }

    void rotatePlayer() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
