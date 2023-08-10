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
    public string SceneToLoad;

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

            case (2): 
                {
                    return WinCon1.PlayerInCharge;
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
            
            SceneManager.LoadScene(SceneToLoad);
            
        }
    }
}
