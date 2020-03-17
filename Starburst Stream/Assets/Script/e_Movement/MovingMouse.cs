using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingMouse : MonoBehaviour
{ // using external dll, Answer by amirabiri 
    /*#if UNITY_STANDALONE_WIN
     [DllImport("user32.dll")]
     static extern bool ClipCursor(ref RECT lpRect);
     public struct RECT
     {
         public int Left;
         public int Top;
         public int Right;
         public int Bottom;
     }
 #endif
*/
// create a sphere
        // add collision to the sphere
        // add a rigid pointer



        
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int XX, int YY);
 
    
    //Call this when you want to set the mouse position
         public bool IsReticleEnabled = true;

        public Camera cam;
        
        private Vector2 mousePos;
        private Vector2 mousePos0;
        private Vector2 mousePost0;
        public Vector2 mousePosDelta;
        private Rigidbody2D m_pointer;
        
        [Range(10f,100f)]public float sensitivity; // how fast will it move
        [Range(1f,7f)]public float radius = 4f; // the reticle's radius
        [SerializeField] private Vector2 Speed; // to monitor the velocity
        private bool freeze = true; // checking Variable change. It's more efficient to use propety with event, but for now we'll use this for the sake of comprehension

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
     freeze=true;
        m_pointer = GetComponent<Rigidbody2D>();mousePost0 = new Vector2(1920/2, 1080/2);
        // using external dll, Answer by amirabiri 
    /*    RECT cursorLimits;
     cursorLimits.Left   = 0;
     cursorLimits.Top    = 0;
     cursorLimits.Right  = Screen.width;
     cursorLimits.Bottom = Screen.height;
     ClipCursor(ref cursorLimits);*/
     // this will be considered


    


     
    }

    

    // Update is called once per frame

    void Update()
    {
        
 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
mousePosDelta = mousePos - mousePos0;

        if (IsReticleEnabled == true){

       StartCoroutine(CheckDif(freeze));
      
        Speed = (mousePosDelta)*new Vector2(sensitivity,sensitivity);

        

       if (!freeze)
        {m_pointer.velocity = Speed;}
        else 
        {m_pointer.velocity = Vector2.zero;}
        StartCoroutine(mousePost(mousePost0));

        radius = 4f;
        
        float NewPointToCentroid = Vector2.Distance(m_pointer.transform.localPosition,Vector2.zero);
    
        if (NewPointToCentroid > radius)
            m_pointer.transform.localPosition *= radius/NewPointToCentroid;
        }
        else m_pointer.transform.position = mousePos;
    }


    IEnumerator CheckDif(bool Freeze)
    {
        
        Vector2 mousePos1 = cam.ScreenToWorldPoint(Input.mousePosition);
        
        yield return new WaitForSeconds(0.1f);
        Vector2 mousePos2 = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (mousePos1==mousePos2) 
        {freeze = true;
        mousePos0 = mousePos2;}
        
        else {freeze = false; }

    }
    IEnumerator mousePost(Vector2 pos)
    {
        SetCursorPos((int)(pos.x), (int)(pos.y));
        yield return new WaitForSeconds(0.1f);
        
    }

    public void OnValueChanged(bool value)
    {
        IsReticleEnabled = value;
    }

    
}
