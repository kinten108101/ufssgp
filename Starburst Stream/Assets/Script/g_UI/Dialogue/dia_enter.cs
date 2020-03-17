using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class dia_enter : MonoBehaviour
{   
    
    
    public string TitleName = "Character";
    [TextArea(1,1024)]public string[] DiagText;
    
    private PlayerController pc;
    private DialogueSystem dial;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log(FindObjectOfType<DialogueSystem>().ReadingDiag);
        pc = collider.GetComponent<PlayerController>();
        if (Input.GetKeyDown(KeyCode.E) && collider.GetComponent<PlayerController>().e_state == Entity.State.full)
        {
            Debug.Log("Started dialogue with " + collider.name);
            dial = FindObjectOfType<DialogueSystem>();
        dial.StartDialogue(TitleName,DiagText);
        pc.e_state = Entity.State.midconv;
        
        
        }
    }

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        dial = FindObjectOfType<DialogueSystem>();
    }
    void Update()
    {
        if (pc.e_state ==Entity.State.midconv) if ( dial.ReadingDiag == false) pc.e_state = Entity.State.full;

    }

}
