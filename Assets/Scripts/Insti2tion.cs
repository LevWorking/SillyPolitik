using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum OrganizationType
{
    Corporate,
    Government
}

public class Insti2tion : MonoBehaviour
{
    public OrganizationType orgType;
    public GameObject targetingPrefab;

    //Stability resources.
    public int popularity;
    public int authority;
    private float auth_difference;

    //Strategic resources. 
    public float funds;
    public int dirt;
    public int military;
    public float scale;

    //Public GameObject 
    void generateSelection(bool can_target_self, float x, float y) 
    {
        GameObject uiInstance = Instantiate(targetingPrefab);    
    }

    void onEndTurn() 
    {
    //Authority of an institution slowly approaches the popularity value. 
    auth_difference = Mathf.Clamp(((float)popularity - (float)authority) / 10, 0, 100);
    authority += (int)auth_difference;
    
    if (orgType == OrganizationType.Corporate) 
        {
            funds += popularity * scale / 5;
        }
    }
}
