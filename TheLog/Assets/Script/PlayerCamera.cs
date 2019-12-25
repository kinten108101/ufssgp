using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {


        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
        
    }
}
