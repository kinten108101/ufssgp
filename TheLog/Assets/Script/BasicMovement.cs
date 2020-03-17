using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //public GameObject cameraobject;
    public Rigidbody2D m_rb; // moving the actual stuff

    public float CameraSpeed;
    private Vector2 move;

    // Start is called before the first frame update move.x = Input.GetAxisRaw("Horizontal") * CameraSpeed; move.y = Input.GetAxisRaw("Vertical") * CameraSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            move.x = 0;
            move.y = CameraSpeed;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            move.x = 0;
            move.y = -CameraSpeed;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            move.x = CameraSpeed;
            move.y = 0;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            move.x = -CameraSpeed;
            move.y = 0;
        }
        else
        {
            move.x = 0;
            move.y = 0;
        }
    }

    void FixedUpdate()
    {

        m_rb.MovePosition(m_rb.position + move*Time.deltaTime);
    }
}
