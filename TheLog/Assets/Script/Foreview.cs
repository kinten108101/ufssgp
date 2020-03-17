using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreview : MonoBehaviour
{
    [Range(10.0f, 200.0f)] public float LaunchForceMultiplier = 100f;
    public Transform forepoint;
    public Transform LeftPoint;
    public Transform RightPoint;
    //public GameObject hitbullet;
    public LineRenderer aimLine;
    public LineRenderer TestLine;


    public GameObject Player;
    public Animator animator;
    private Rigidbody2D rb;
    private CharacterController2D controller;

    public Camera cam;
    private Vector2 mouse;  
    
    private PlayerController pc;
    public bool hanging;
    public bool HangingMode;



    private Vector2 hitNormal;

    Quaternion Backuprotation; //Previous rotation before launching, useful later on
    //deprecated


    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        HangingMode = false;
        controller = GetComponent<CharacterController2D>();
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        pc.enabled = true;
        hanging = false; 
        rb.isKinematic = false;
    }       
    void Update()
    {
        
        
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mouse - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        
        
        if (Input.GetButtonDown("Fire1"))
        {
           StartCoroutine( UpdateRaycast(forepoint.transform, aimDirection, hitNormal));
        }

        //Cancel the hanging
        


        //drawing the line based on LeftPlayer and RightPlayer

        //DrawLine(aimLine, forepoint.position, mouse);

        if (Input.GetKeyDown(KeyCode.P))
            HangingMode = !HangingMode;
        


        if (HangingMode)
        {
            if (hanging == false)
            {
                Backuprotation = Quaternion.identity;
            }
        }



        //Here to stop hanging
        if (Input.GetButtonDown("Jump") && hanging) // press jump to stop hanging
            Release();
        


        //Update current hanging status
        animator.SetBool("Hanging",hanging);

    }


    IEnumerator UpdateRaycast(Transform pointBlank, Vector2 direction, Vector2 hitNormal)
    {
        

        Vector3 LastPosition = rb.position;
        rb = GetComponent<Rigidbody2D>();
        RaycastHit2D hit = Physics2D.Raycast( pointBlank.position, direction );
        hitNormal = hit.normal;
        /*if (hit.collider.bounds.Contains(hitNormal))
        {
            Debug.LogError("hitpoint is contained");
        }*/
        
        float distance = Mathf.Sqrt(Mathf.Pow(hit.point.x - rb.position.x, 2) + Mathf.Pow(hit.point.y - rb.position.y, 2));
        if (hit==true && distance <=30f && hit.rigidbody != rb)
        {
            //hit.normal.t;

            //Vector2 worldnormal = Vector2.Cross(direction, hit.normal);
            float hitNormalAngle = - 90f + Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg;
            // Debug.Log(hitNormalAngle);
            //  Debug.Log(Vector2.right.x+","+ Vector2.right.y);


            
            hanging = true;
            Debug.Log(distance);
            Backuprotation = Player.transform.rotation;
            Player.transform.position = hit.point;
            Player.transform.rotation = Quaternion.AngleAxis(hitNormalAngle,Vector3.forward);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            forepoint.localPosition = new Vector3(0f, 2f, 0f);
            //freeze the player HERE

            


            // }
            
            DrawLine(aimLine, rb.position, hit.point) ;

            aimLine.enabled = true;
            yield return new WaitForSeconds(0.05f);
            aimLine.enabled = false;
        }
        else if (hit==true && distance > 30)
        {
            Debug.Log("Hit far away");
            Release();
            rb.AddForce(direction*LaunchForceMultiplier);
        }
        else if (hit == true && distance <= 30 && hit.rigidbody == rb)
        {
            Debug.Log("Hit self");            
        }
        else if (hit == false)
        {
            Debug.Log("Hit out of bound");
            Release();
            rb.AddForce(direction * LaunchForceMultiplier);
        }


    }

    void Release()
    {
        forepoint.localPosition = new Vector3(1f, 0f, 0f);
        pc.jump = true;
        animator.SetBool("InAir", true);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // actually this is default



        hanging = false; // always

        

    }

    void DrawLine(LineRenderer line ,Vector3 from, Vector3 to)
    {
        line.SetPosition(0, from);
        line.SetPosition(1, to);
    }
}
