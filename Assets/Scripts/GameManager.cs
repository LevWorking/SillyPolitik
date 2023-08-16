using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using static Institution;

public class GameManager : MonoBehaviour
{
    public int turnNumber;
    public Institution WinCon1;
    public TextMeshProUGUI turnText;
    public string SceneToLoad;

    public bool isCutScene;
    public List<Institution> orgInstances = new List<Institution>();

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

    private void Start() 
    {
        Institution[] scripts = FindObjectsOfType<Institution>();
        orgInstances.AddRange(scripts);
    }

    public void EndTurn() 
    {
        turnNumber += 1;
        turnText.text = "Turn " + turnNumber.ToString();

        foreach (Institution script in orgInstances)
        {
            
            script.UpdateResources(true);
        }

        if (CheckWinCondition())
        {
            
            SceneManager.LoadScene(SceneToLoad);
            
        }
    }

    public void CutSceneComplete() 
    {
        if (isCutScene) 
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    
    }
}
