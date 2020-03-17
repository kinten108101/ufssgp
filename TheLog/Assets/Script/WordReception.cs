using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordReception : MonoBehaviour
{

    public InputField cmd_Input1;
    public Rigidbody2D m_rigidbody;
    public GameObject player;
    public PlayerController pcontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        pcontroller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        OnEndEdit();
        OnDebug();
        AirCheckTilting();
        
    }
    public void OnEndEdit()
    
    {
        if (cmd_Input1.text == "Moveright")
        {
            m_rigidbody.velocity += new Vector2(10, 0);
            Clc(cmd_Input1);
        }
    }


    void Clc(InputField input)
    {
        input.text = "";
    }
    void OnDebug()
    {
        Debug.Log(m_rigidbody.velocity.y);
    }
    void AirCheckTilting()
    {
        
        if (pcontroller.jump) {
            Vector2 jump1 = new Vector2(m_rigidbody.velocity.x,m_rigidbody.velocity.y*10);
            Vector2 jump2 = new Vector2(-m_rigidbody.velocity.x, -m_rigidbody.velocity.y*10);
            if (m_rigidbody.velocity.y >= 0 && 6>m_rigidbody.velocity.y)
                player.transform.rotation = Quaternion.LookRotation(Vector3.forward, jump1);
            else if (m_rigidbody.velocity.y < 0) player.transform.rotation = Quaternion.LookRotation(Vector3.forward, jump2);
        }
        
    }
}
