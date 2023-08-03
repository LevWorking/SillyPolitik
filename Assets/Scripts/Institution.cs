using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public InstitutionType instType;
    public AuthorityType authType;
    public int controlPoints;
    public int maxControlPoints;
    public Image controlImage;

    public void ChangeControl(int control_change) 
    {
        controlPoints   += control_change;
        controlImage.fillAmount = (float)controlPoints / (float)maxControlPoints;
        controlPoints = Mathf.Clamp(controlPoints, 0, maxControlPoints);
    }

    void Awake()
    {
        ChangeControl(0);
    }
}