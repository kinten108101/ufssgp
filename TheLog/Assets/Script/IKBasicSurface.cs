
using UnityEngine;

public class surfaceHit
{
    
}
public class IKBasicSurface : MonoBehaviour
{
    public GameObject point;
    public GameObject player;

    private Rigidbody2D rb;
    private CharacterController2D controller;
    private PlayerController pcontroller;
    private Foreview fcontroller;
    
    // Start is called before the first frame update

    void Start()
    {
        controller = player.GetComponent<CharacterController2D>();
        pcontroller = player.GetComponent<PlayerController>();
        fcontroller = player.GetComponent<Foreview>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Transform pos = point.transform;
        
        Vector2 dir = new Vector2(0f, -1f);
        SurfaceCast(pos, dir);
        
    }

    void OnCollisionEnter(Collision col_p)
    {
        Debug.Log(col_p.collider.name);
    }

    void SurfaceCast(Transform hitpos, Vector2 hitdir)
    {
        
        RaycastHit2D hit = Physics2D.Raycast(hitpos.position, hitdir);
        
        

        float distance = Mathf.Sqrt(Mathf.Pow(hit.point.x - rb.position.x, 2) + Mathf.Pow(hit.point.y - rb.position.y, 2));
        float hitNormalAngle = -90f + Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg;
        if (!pcontroller.jump && !fcontroller.hanging)
            player.transform.rotation = Quaternion.AngleAxis(hitNormalAngle, Vector3.forward);
        else if (!fcontroller.hanging) player.transform.rotation = Quaternion.identity;
        if (!controller.m_FacingRight) player.transform.Rotate(0f, 180f, 0f);
    }
}
