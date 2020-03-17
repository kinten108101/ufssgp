using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDashing : MonoBehaviour
{
    public GameObject mouse;
    public GameObject player;
    private Rigidbody2D m_rb;
    public float dashSpeed;

    

    public Camera cam;
    private Vector2 mousePosDelta;
    private Vector2 mousePos;
    private Vector2 mousePos0;
    public MovingMouse movingMouse;
    public PlayerController playercontroller;
    public Animator animator;

    [Range(0.1f, 1.5f)]public float DashDelay = 1f; // unit: second
    // Start is called before the first frame update
    void Start()
    {
        m_rb = player.GetComponent<Rigidbody2D>();
        movingMouse = mouse.GetComponent<MovingMouse>();
        playercontroller = player.GetComponent<PlayerController>();
        animator= player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mouse.transform.position;
        mousePos0 = m_rb.position;
        mousePosDelta = mousePos - mousePos0;
        
        // if press, start coroutine
if (Input.GetKeyDown(KeyCode.Space)) StartCoroutine(OnDashing());
    }

    IEnumerator OnDashing()
    {
        
        // Move player
        //Debug.Log(movingMouse.mousePosDelta);
     
        float dashDistance = movingMouse.radius;
        float DistanceSqrt = Mathf.Sqrt(Mathf.Pow(mousePosDelta.x,2) + Mathf.Pow(mousePosDelta.y,2));

        playercontroller.isDashing = true;
        
        m_rb.velocity = new Vector2(dashSpeed,dashSpeed)*mousePosDelta*(dashDistance/DistanceSqrt);
        playercontroller.move     = m_rb.velocity;
     //AddForce won't be strong enough to steer directinos:
        //timeout before stop
yield return new WaitForSeconds(DashDelay);
        playercontroller.move.x=Input.GetAxisRaw("Horizontal");
        playercontroller.move.y=Input.GetAxisRaw("Vertical");
        playercontroller.isDashing = false;
        
        
        // Add trail remember that there is 1. a black outline effect sprite turning white and purple 2. flicking 3. lasting silhouette 4. small explosion under the feet 5. rubbles being blown by the wind --------- a wosh sound ending with flicking sound

        //Penalty delay
    }
}
