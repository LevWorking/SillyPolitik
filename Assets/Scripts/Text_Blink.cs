using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_Blink : MonoBehaviour
{
    public TextMeshProUGUI blinky_boy;
    public float fade_in_time;
    public float stay_time;
    public float fade_out_time;

    private float time_checker;
    private Color _color;
    // Start is called before the first frame update
    void Start()
    {
        //blinky_boy = GetComponent<Text>();
        _color = blinky_boy.color;
    }

    // Update is called once per frame
    void Update()
    {
        time_checker += Time.deltaTime;
        if (time_checker < fade_in_time) 
        {
            blinky_boy.color = new Color(_color.r, _color.g, _color.b, time_checker / fade_in_time);
        }

        else if (time_checker < fade_in_time + stay_time)
        {
            blinky_boy.color = new Color(_color.r, _color.g, _color.b, 1);
        }

        else if (time_checker < fade_in_time + stay_time + fade_out_time)
        {
            blinky_boy.color = new Color(_color.r, _color.g, _color.b, (time_checker - (fade_in_time + stay_time)) / fade_out_time);
        }

        else 
        {
            time_checker = 0;
        }

    }
}
