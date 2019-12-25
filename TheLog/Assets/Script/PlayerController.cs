using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public CharacterController2D controller;
    public Animator animator;
    public float Speed = 50f;
    private float Speed1 = 0f;
    public float SpeedLimit = 100f;
    public float acceleration = 0.5f;
    public float Gravity = 3f;
    float horizontalMove = 0f;
    bool jump;
    bool crouch;
    public float QuadraticSpeed;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            if (Speed1 <= SpeedLimit)

            {
                Speed1 += Speed1 * acceleration;
            }
            else
            { Speed1 = SpeedLimit; }
            
            horizontalMove = horizontal * Speed1;
        }
        else
        {
            Speed1 = Speed;
            horizontalMove = 0;
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }

    void FixedUpdate ()
    {
        Debug.Log(Speed1);
        Debug.Log(horizontalMove);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
