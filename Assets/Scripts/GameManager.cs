using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int turnNumber;
    public Institution WinCon1;
    public TextMeshProUGUI turnText;

    //Checks if the gamestate meets the current win condition
    public bool CheckWinCondition()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case (1):
                {
                    if (WinCon1.controlPoints >= 3)
                    {
                        return true;
                    }
                    else 
                    { 
                        return false; 
                    }
                    
                    
                }
            default: return false;
        }
    }

    public void EndTurn() 
    {
        turnNumber += 1;
        turnText.text = "Turn " + turnNumber.ToString();

        if (CheckWinCondition())
        {
            
            SceneManager.LoadScene(0);
            
        }
    }
}
