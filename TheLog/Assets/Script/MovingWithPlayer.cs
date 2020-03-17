using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithPlayer : MonoBehaviour
{
    public GameObject target;
    private Vector3 Distance;

    void Start()
    {
        Distance = transform.position - target.transform.position;
    }
    void FixedUpdate()
    {
        
        transform.position = Distance + target.transform.position;
    }

}
