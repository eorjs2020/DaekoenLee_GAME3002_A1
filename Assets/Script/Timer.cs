using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text countTimerText;

    public float time, minutes, seconds;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 600f;
        countTimerText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);
        countTimerText.text = "Timer : " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
