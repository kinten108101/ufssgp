using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//*

//*/

public class ColliderInfo
{
    public int targetLayer = 26; //hitableobjects
     public enum CollisionType{open=2,closed = 0,collided = 1}
    
   
}


/*public class _E_HITBOX{
    public Collider[] overlap;
    public Vector3 position;
    public Vector3 size;
    public Quaternion rotation;
    public int layer;

}*/

public class e_hurtbox : MonoBehaviour
{
    public bool EnableCollision = true;
    public ColliderInfo colin;
    public ColliderInfo.CollisionType colstate;
    
       
        
    // General hutbox checking for all entities: red if overlapped, green if not.
    void Start()
    {
        colstate = ColliderInfo.CollisionType.open;
    }

    // Update is called once per frame
    void Update()
    {
        HurtboxCheck();
        
    }
    //*
    void HurtboxCheck()
    {   
        
        /*
        if (EnableCollision)
    
            {
                Collider2D[] hitbox_overlap = Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,2f),0f,HitboxGlobal.targetlayer);
            if (hitbox_overlap.Length > 0) colstate = ColliderInfo.CollisionType.collided;
            else colstate = ColliderInfo.CollisionType.open;}
        else colstate = ColliderInfo.CollisionType.closed;
        //*/
            
    }
    //*/
    public void OnDrawGizmos()
    {
        Color GizmoColor()
    
        {
        ColliderInfo.CollisionType colstate = ColliderInfo.CollisionType.closed;
        Color color = Color.black;
        switch (colstate)
        {
            case ColliderInfo.CollisionType.open:
            color = Color.green;
            break;
            case ColliderInfo.CollisionType.closed:
            color = Color.yellow;
            break;
            case ColliderInfo.CollisionType.collided:
            color = Color.red;
            break;
        }
        return color;
        
        }

        Gizmos.color = GizmoColor();
        Gizmos.DrawCube(transform.position,new Vector3(1,2,1));
    }

}

