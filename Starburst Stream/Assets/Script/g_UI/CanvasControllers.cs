using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControllers : MonoBehaviour
{
    public Toggle button;
    public GameObject mouse;
    private MovingMouse movingMouse;
    public GameObject player;
    private Canvas canvas;
    public Camera cam;
    // Start is called before the first frame update
    public Vector2 offset = new Vector2(0f,2f);
    void Start()
    {
    movingMouse = mouse.GetComponent<MovingMouse>();
    
    canvas = GetComponent<Canvas>();
    
    
    

    }
    void Update()
    {
button.transform.position = cam.WorldToScreenPoint((Vector2)player.transform.position + offset);
    }
    
    public void OnChangeValue(bool value)
    {
        
        
        
        movingMouse.IsReticleEnabled = value;
    }
  
}
