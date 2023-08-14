using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
{
    public Image targetImage;
    
    public Sprite image1;
    public Sprite image2;

    public bool switching_is_active;
    public float switching_period;
    float current_time = 0;

    void Update() 
    {
        if (switching_is_active)
        
        { 
            SwitchImages(); 
        }
    }
    
    public void SwitchImages() 
    {
        current_time += Time.deltaTime;
        
        if (current_time > switching_period) 
        {
            if (targetImage.sprite == image1) 
            { 
                targetImage.sprite = image2;
            }

            else
            {
                targetImage.sprite = image1;
            }

            current_time = 0;
        }
    }
}
