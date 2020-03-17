using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Entity{
public enum Direction
    {
        down,
        up,
        right,
        left,
    }
public enum State
{
    full,
    midconv,
}
}

public class PlayerController : MonoBehaviour
{
    
    
    public GameObject player;
    private Rigidbody2D e_rb;
    public GameObject directionObject;
    

    public Vector2 move;
    private Vector2 move0;
    public float e_speed;

    private Animator animator;
    public bool isDashing;
    public Entity.Direction direction = Entity.Direction.down;
    public Entity.State e_state = Entity.State.full;

    //Other global references
    private MovingDashing movingDashing;
    //For testcases
    private bool permission = true;

    // Start is called before the first frame update
    void Start()
    {
        e_rb = player.GetComponent<Rigidbody2D>();
        move = e_rb.velocity;
        move0= Vector2.zero;
        animator = player.GetComponent<Animator>();
        movingDashing = player.GetComponent<MovingDashing>();
        permission = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        UpdateMovement(permission);
        
    }
    void UpdateState()
    {
        if (e_state == Entity.State.midconv) {permission = false;}
        else if (e_state == Entity.State.full) {permission = true;}
        
    }

    void UpdateMovement(bool perm)
    {
        if (perm){
            movingDashing.enabled = true;
            if (!isDashing)
        {
            move.x=Input.GetAxisRaw("Horizontal");
            move.y=Input.GetAxisRaw("Vertical");
            //Debug.Log(isDashing);
            }
        animator.SetFloat("X",move.x);animator.SetFloat("Y",move.y);
/*
        CheckDirection();
        if (move.x!=0 || move.y!=0)        
            move0= move;
        else {animator.SetFloat("LastX",move0.x);animator.SetFloat("LastY",move0.y);}
        //*/
        ChangeDirection();
        SetIdleToDirection();
        DirectionPointer();
        }
        else movingDashing.enabled = false;
    }
    
    void FixedUpdate(){
        if (!isDashing)
        e_rb.MovePosition(e_rb.position + move*Time.fixedDeltaTime*e_speed);
    }
    /*
    void CheckDirection()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
       {
            if (move0.x >0) direction = e_Direction.right;
            else if (move0.x < 0) direction = e_Direction.left; }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                if (move0.y>0) direction = e_Direction.up;
                else if (move0.y<0) direction = e_Direction.down;
                
            }
       
       
    }
    //*/
    void ChangeDirection()
    { 

        if (Input.GetKeyUp(KeyCode.A)) {direction = Entity.Direction.left;}
        else if (Input.GetKeyUp(KeyCode.D)) {direction = Entity.Direction.right;}
        else if (Input.GetKeyUp(KeyCode.W)) {direction = Entity.Direction.up;}
        else if (Input.GetKeyUp(KeyCode.S)) {direction = Entity.Direction.down;}
    }
    void SetIdleToDirection()
    {
        switch (direction)
        {
            case Entity.Direction.left: animator.SetFloat("LastX",-1f);animator.SetFloat("LastY",0f); break;
            case Entity.Direction.right: animator.SetFloat("LastX",1f);animator.SetFloat("LastY",0f); break;
            case Entity.Direction.up: animator.SetFloat("LastX",0f);animator.SetFloat("LastY",1f); break;
            case Entity.Direction.down: animator.SetFloat("LastX",0f);animator.SetFloat("LastY",-1f); break;
        }
    }


       void DirectionPointer(){
       switch(direction){
           
        case Entity.Direction.down: directionObject.transform.SetPositionAndRotation(directionObject.transform.position,Quaternion.Euler(0f,0f,-90f)); break;
        case Entity.Direction.up: directionObject.transform.SetPositionAndRotation(directionObject.transform.position,Quaternion.Euler(0f,0f,90f)); break;
        case Entity.Direction.left: directionObject.transform.SetPositionAndRotation(directionObject.transform.position,Quaternion.Euler(0f,0f,180f)); break;
        case Entity.Direction.right: directionObject.transform.SetPositionAndRotation(directionObject.transform.position,Quaternion.Euler(0f,0f,0f)); break;
       }
       }
}
