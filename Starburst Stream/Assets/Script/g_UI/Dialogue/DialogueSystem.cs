using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;





public class DialogueSystem : MonoBehaviour
{
   
    // Start is called before the first frame update
    public string e_Name;
    public Queue<string> sentences = new Queue<string>();

    public GameObject Diag;
    public TextMeshProUGUI TitleName;
    public RectTransform Panel;
    public TextMeshProUGUI diagText;
    
    
    public bool ReadingDiag = false;

    public string SaveJSON()
    {
        
        return JsonUtility.ToJson(this);
    }
    void Start()
    {
        /*
        foreach (Transform child in transform)
        {
            if (child.tag == "diag") 
            {Diag = child.GetComponent<GameObject>(); 
                foreach (Transform grandchild in child){
                   TitleName = grandchild.Find("TitleName").GetComponent<Text>(); 
                   Panel = grandchild.Find("Panel").GetComponent<RectTransform>(); 
                    diagText = grandchild.Find("diagText").GetComponent<Text>();
                } 
            }
        }
        //*/
        ReadingDiag = false;
        e_Name = TitleName.text;
        
        Diag.SetActive(false);
        
    }
    // Update is called once per frame
    

    public void StartDialogue(string titlename, string[] diagtext)
    {
        Diag.SetActive(true);
        ReadingDiag = true;
        foreach (string dtext in diagtext) sentences.Enqueue(dtext);
        TitleName.text = titlename;
        StartCoroutine(UpdateText(sentences));
    }
    IEnumerator UpdateText(IEnumerable textQueue)
    {
        
        foreach (string sentence in textQueue)
        {
            diagText.text = "";
            foreach (char character in sentence)
            {diagText.text += character;
            yield return new WaitForSeconds(0.05f);
            //if (Input.GetKeyDown(KeyCode.E)) break; 
            }
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) == true);
            
            
        }
        ReadingDiag = false;
        Diag.SetActive(false);
    }
}
