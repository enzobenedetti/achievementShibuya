using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    public Text sentenceText;

    public Text successText;

    private float timeOnScreen = 4f;

    private float timerBalise;
    // Start is called before the first frame update
    void Start()
    {
        sentenceText.text = " ";
        successText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + Score.GameScore;
        if (Time.time >= timerBalise + timeOnScreen)
        {
            sentenceText.text = " ";
            successText.text = " ";
            timerBalise = float.MaxValue - timeOnScreen;
        }
    }

    public void ShowAchievement(string sentence, string success)
    {
        sentenceText.text = sentence;
        successText.text = success;
        timerBalise = Time.time;
    }
}
