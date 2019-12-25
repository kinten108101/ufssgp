using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreview : MonoBehaviour
{
    public Transform forepoint;
    public Transform LeftPoint;
    public Transform RightPoint;
    //public GameObject hitbullet;
    public LineRenderer aimLine;
    public GameObject Player;
    public Animator animator;
    private Rigidbody2D rb;
    private CharacterController2D controller;

    public Camera cam;
    private Vector2 mouse;  
    
    private PlayerController pc;
    public bool hanging;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        pc.enabled = true;
        hanging = false;
        rb.isKinematic = false;
    }       
    void Update()
    {
        controller = GetComponent<CharacterController2D>();
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Jump"))
        {
            
            pc.enabled = true;
            rb.isKinematic = false;
            if (hanging)
            { transform.rotation = Quaternion.Euler(0, 0, 0); hanging = false; }
        }
        Vector2 forepoint1 = forepoint.position;
        if (controller.m_FacingRight)
        {
            aimLine.SetPosition(0, RightPoint.position);
        }
        else
            {
            aimLine.SetPosition(0, LeftPoint.position);
        }
        aimLine.SetPosition(1, mouse);
        animator.SetBool("hanging",hanging);

    }
    void Shoot()
    {
        rb = GetComponent<Rigidbody2D>();
        RaycastHit2D hit = Physics2D.Raycast( forepoint.position, forepoint.right );

        if (hit==true)
        {
            hanging = true;
            Debug.Log(hit.transform.localRotation);
            Player.transform.position = hit.point;
            Player.transform.rotation = hit.transform.localRotation;
            rb.isKinematic = true;
            pc.enabled = false;
            
            // }
        }
        else
        {
            Debug.Log("Hit null");
        }
    }
}
