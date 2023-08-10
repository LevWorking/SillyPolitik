using UnityEngine;
using UnityEngine.UI;

public class Button_Handler : MonoBehaviour
{
    public Institution powerCause;
    public Institution powerTarget;// Assign this in the Inspector
    public int controlReduction = 1; // Adjust as needed

    //Used to call the Spread Misery Institution Function. See Institution.SpreadMisery();
    public void CallSpreadMisery()
    {
        if (powerTarget != null)
        {
            powerCause.SpreadMisery(powerTarget, controlReduction);
        }
        else
        {
            Debug.LogWarning("Misery target not assigned.");
        }
    }

    //Used to call an attempt to gain control of an institution. See Institution.AttemptControl();
    public void CallControlAttempt() 
    { 
        if (powerTarget != null) 
        {
            powerTarget.AttemptControl();
        }

        else
        {
            Debug.LogWarning("Control target not assigned.");
        }
    }
}