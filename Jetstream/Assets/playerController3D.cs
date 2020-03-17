using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController3D : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody e_rb;
   public Vector3 move;
   public bool isDashing;
    public float e_speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<GameObject>();
        e_rb = this.GetComponent<Rigidbody>();
    }
    void Update(){
        UpdateMovement();
    }
    // Update is called once per frame
    void UpdateMovement()
    {
        
            move.x=Input.GetAxisRaw("Horizontal");
            move.z=Input.GetAxisRaw("Vertical");
            //Debug.Log(isDashing);
            }
        //animator.SetFloat("X",move.x);animator.SetFloat("Y",move.y);
/*
        CheckDirection();
        if (move.x!=0 || move.y!=0)        
            move0= move;
        else {animator.SetFloat("LastX",move0.x);animator.SetFloat("LastY",move0.y);}
        //*/
        
        
        //else movingDashing.enabled = false;
    
    
    void FixedUpdate(){
        
        
        e_rb.MovePosition(e_rb.position + move*Time.fixedDeltaTime*e_speed);
    }
}
