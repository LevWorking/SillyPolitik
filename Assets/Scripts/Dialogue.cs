using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    //Stops the coroutine if the line of dialogue is complete. Skips to the complete text if it isn't complete.
    public void SkipDialogue()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }

    }

    //Ensures that he dialogue starts empty. 
    void Start() 
    { 
        textComponent.text = string.Empty;
        StartDialogue();
    }

    //Called to start the process of putting the text on the screen.
    void StartDialogue() 
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    //Every textSpeed amount of time, add a new character to the dialogue on screen.
    IEnumerator TypeLine() 
    { 
        foreach (char c in lines[index].ToCharArray()) 
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
        
            }
    }

    //If the full line of dialogue has been done, do nothing, otherwise call TypeLine()
    void NextLine () 
    {
    if (index < lines.Length - 1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    else 
        {
            ;
            //gameObject.SetActive(false);
        }
    }

    //Every tick, skip the dialoge if the enter key is down. 
   void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SkipDialogue();
        }
    
    }
}
