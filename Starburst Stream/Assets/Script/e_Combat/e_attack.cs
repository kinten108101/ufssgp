using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitboxGlobal
{
    public static LayerMask targetlayer = LayerMask.GetMask("hitableobjects");
    [Range(0f,1.5f)]public static float HitboxDelay = 0.5f;
    public static void Damage(GameObject target, float damage)
    {

    }
}

public class e_attack : MonoBehaviour
{
    public GameObject e_hitpoint;
    private ColliderInfo colin;
    private ColliderInfo.CollisionType colstate;
    
    
    
    // checking player pressing the attack button. For melee/ranged switching 
    void Start()
    {
        colstate = ColliderInfo.CollisionType.open;
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        HitboxStart();
    }
    void HitboxStart()
    {
        //yield return new WaitForSeconds(1f);
        Collider2D[] overlapping = Physics2D.OverlapBoxAll(e_hitpoint.transform.position,new Vector2(1f,2f),0f,HitboxGlobal.targetlayer.value);

        //Collider2D[] overlapping = Physics2D.OverlapCircleAll(e_hitpoint.transform.position, 0f, targetlayer.value);
        if (overlapping.Length >0)
        {
            
            colstate = ColliderInfo.CollisionType.collided;
            foreach (Collider2D targetObject in overlapping)
            {
                StartCoroutine(Strike(targetObject));
                // Set animation, decrease health, knockback...
            }
        }
        
        
        
    }
    IEnumerator Strike(Collider2D targetob)

    {Debug.Log("HIT "+targetob.name);   if (targetob.GetComponent<e_hurtbox>().colstate != ColliderInfo.CollisionType.closed){
        targetob.GetComponent<e_hurtbox>().colstate = ColliderInfo.CollisionType.collided;
        colstate = ColliderInfo.CollisionType.collided;
        
        yield return new WaitForSeconds(HitboxGlobal.HitboxDelay);
        targetob.GetComponent<e_hurtbox>().colstate = ColliderInfo.CollisionType.open;}
        colstate = ColliderInfo.CollisionType.open;
    }

    public void OnDrawGizmos()
    {
        Color GizmoColor()
    
        {
        
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
        Gizmos.DrawCube(e_hitpoint.transform.position,new Vector3(1,2,1));
    }
}
