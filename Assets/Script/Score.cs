using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text score;
    public static int scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
       score = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + scoreValue.ToString("00");
    }
}
