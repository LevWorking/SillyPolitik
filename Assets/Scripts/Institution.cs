using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public enum InstitutionType
{ 
    Residential,
    Local,
    Regional,
    National,
    Corporate
}

public enum AuthorityType
{
    Ministry,
    Council,
    Assembly
}

public class Institution : MonoBehaviour
{
    //Mostly flavor for the moment.
    public InstitutionType instType;
    public AuthorityType authType;
    
    //Variables relating to control, the control bar, and popularity. 
    public int controlPoints;
    public int maxControlPoints;
    public Image controlImage;
    public Color playerColor = Color.white;
    
    //Variables relating to the color of the control bar.
    public Button buttonToChange;
    private Image imageComponent;


    //Booleans relating to victory, popularity, and player control. 
    public bool WinConMet;
    public bool UsesPopularity;
    public bool PlayerInCharge;


    //Variables for resources
    public int funds;
    public int dirt;
    public int fundsIncome;
    public int dirtIncome;
    public int force;
    public int forceIncome;

    public TextMeshProUGUI resourceText;
    
    //Sets the control bar to the predetermined value.
    void Awake()
    {
        ChangeControl(0);
    }

    void Start()
    {
        imageComponent = buttonToChange.GetComponentInParent<Image>();
        UpdateResources(false);
    }


    //Change the control points by control_change, update the control bar to that fraction. 
    public void ChangeControl(int control_change) 
    {
        controlPoints   += control_change;
        controlImage.fillAmount = (float)controlPoints / (float)maxControlPoints;
        controlPoints = Mathf.Clamp(controlPoints, 0, maxControlPoints);

    }

    //Update the resource text. takeIncome controls if resources go up as though it were the end of the turn.
    public void UpdateResources(bool takeIncome) 
    {
        if (takeIncome)
        {
            dirt += dirtIncome;
            funds += fundsIncome;
            force += forceIncome;
        }

        if (resourceText != null)
        {
            resourceText.text = string.Format("Dirt: {0} ({1}{2})", dirt, dirtIncome < 0 ? "" : "+", dirtIncome);
            resourceText.text += string.Format("<br>Funds: {0} ({1}{2})", funds, fundsIncome < 0 ? "" : "+", fundsIncome);
            resourceText.text += string.Format("<br>Force: {0} ({1}{2})", force, forceIncome < 0 ? "" : "+", forceIncome);
        }
    }

    /*Availible if the Institution has the Spread Misery Power.
     Causes a reduction in control points. */
    public void SpreadMisery(Institution miseryTarget, int misery_control_change)
    {
        //Debug.Log("SpreadMisery called with control change: " + misery_control_change);

        miseryTarget.controlPoints -= misery_control_change;
        //Debug.Log("Updated control points: " + miseryTarget.controlPoints);

        miseryTarget.ChangeControl(0); // Update the control bar after reducing control points
    }


    /*If the player doesn't already control the institution, and the institution is only 40% under 
    the control of another faction, the player gains control. */
    public void AttemptControl()
    {
        if (!PlayerInCharge && ((float)controlPoints / (float)maxControlPoints) < 0.4)
        {
            PlayerInCharge = true;
            controlPoints += 3;
            ChangeControl(0);

            ColorBlock colors = buttonToChange.colors;
            colors.normalColor = Color.white; // Change the normal color of the Button
            buttonToChange.colors = colors;
        }
    }

 
}