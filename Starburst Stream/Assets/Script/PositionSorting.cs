using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSorting : MonoBehaviour
{
    [SerializeField]
    private int SortingBase = 5000;
    [SerializeField]
    private int offset = -10;
    
    private Renderer render;

    void Awake()
    {
        render = gameObject.GetComponent<Renderer>(); //define this object's Renderer
    }
    void LateUpdate()
    {
        render.sortingOrder = (int)(SortingBase-transform.localPosition.y - offset); //calculate
    }
}
