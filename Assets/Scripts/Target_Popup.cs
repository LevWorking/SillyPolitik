using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Popup : MonoBehaviour
{
    public GameObject game_object;
    bool isComplex;

    void Awake() 
    {
        if (!isComplex)
        {
            game_object.SetActive(false);
        }
        
    }
    
}
