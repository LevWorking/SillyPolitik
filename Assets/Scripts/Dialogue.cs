using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    //Section Relevant only to conversations.
    //Target image to stop from talking once dialogue is over. 
    public Image_Switch TalkingTarget;
    public bool isConversation;
    public Color color1;
    public Color color2;
    
    //To notify the game manager when dialogue is done. 
    public GameManager gameManager;

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
        
        
        if (isConversation) 
        {
            //textComponent.richText = true;
            textComponent.color = color1;  
        }

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
            SwitchColors();
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    else 
        {
            if (TalkingTarget != null) 
            { 
            TalkingTarget.switching_is_active = false;
            }
            //gameObject.SetActive(false);

            gameManager.CutSceneComplete();
        }
    }

    //Switches between two preselected colors every line.
    public void SwitchColors()
    {
        if (textComponent.color == color1)
        {
            textComponent.color = color2;
        }
        else
        {
            textComponent.color = color1;
        }
        Debug.Log("Color Switched");
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
