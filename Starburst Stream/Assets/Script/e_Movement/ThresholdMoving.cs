using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdMoving : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 distance;
    public GameObject Follower; // camera, zone, ...
    public GameObject Followed; // player
    void Start()
    {
        distance = Follower.transform.position - Followed.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follower.transform.position = distance + Followed.transform.position;
    }
}
