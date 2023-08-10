using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    //Sets the control bar to the predetermined value.
    void Awake()
    {
        ChangeControl(0);
    }

    void Start()
    {
        imageComponent = buttonToChange.GetComponentInParent<Image>();
    }


    //Change the control points by control_change, update the control bar to that fraction. 
    public void ChangeControl(int control_change) 
    {
        controlPoints   += control_change;
        controlImage.fillAmount = (float)controlPoints / (float)maxControlPoints;
        controlPoints = Mathf.Clamp(controlPoints, 0, maxControlPoints);

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