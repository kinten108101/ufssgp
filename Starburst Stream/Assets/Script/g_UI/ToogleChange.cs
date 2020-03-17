using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleChange : MonoBehaviour
{
    public Toggle button;
    public GameObject mouse;
    private MovingMouse movingMouse;
    bool enter;
    // Start is called before the first frame update
    void Start()
    {
    movingMouse = mouse.GetComponent<MovingMouse>();
    
    enter = movingMouse.IsReticleEnabled;
    
    button = this.GetComponent<Toggle>();

    }
    
    public void OnChangeValue()
    {

        if (button.isOn) enter = true;
        else enter = false;
    }
    
}
