using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canera
{
    public float horizontal;
    public float vertical;
    public float speed;
    
}

public class CaneraDrag : MonoBehaviour
{
    public Vector2 mouseCam;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseCam = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.J))
        Debug.Log(mouseCam);
        MoveField();
    }

    void FixedUpdate()
    {
       
    }

    void MoveField()
    {
        
        
    }
}
