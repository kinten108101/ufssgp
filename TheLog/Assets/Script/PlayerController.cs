using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //   private Rigidbody2D rb;
    Vector3 LocalScale1;

    public CharacterController2D controller;
    public Animator animator;
    private bool RunStart = true;
    private float animSpeedLimit = 10.0f;
    private float animSpeedCurrent;
    public float Speed = 50f;
    private float SpeedCurrent = 0f;
    public float SpeedLimit = 100f;
    public float acceleration = 0.5f;
    public float Gravity = 3f;
    float horizontalMove = 0f;
   public  bool jump;
    bool crouch;
  
    public float QuadraticSpeed;

    void Start()
    {
        LocalScale1 = this.transform.localScale;
        animSpeedLimit = 10.0f;

    }
    // Update is called once per frame
    void Update()
    {
       // rb = GetComponent<Rigidbody2D>();
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        
           
            horizontalMove = horizontal * SpeedLimit;
   
        AnimationSpeed(animSpeedLimit);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("InAir", true);
        }
        
    }

    void AnimationSpeed(float x)
    {
        animator.SetFloat("ansp", x);
    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("InAir", false);
    }

    void FixedUpdate ()
    {
        //Debug.Log(Speed);
        //Debug.Log(animSpeedCurrent);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
    }
}
