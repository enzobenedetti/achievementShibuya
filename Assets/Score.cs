using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int _score;

    public static int GameScore
    {
        get => _score;
        set
        {
            _score = value;
            if (_score > 0) return;
            _score = 0;
        }
    }

    public static Action ScoreUp;

    public static void ScoreImprove()
    {
        GameScore++;
        ScoreUp?.Invoke();
    }

    public static void ScoreDecrease()
    {
        GameScore--;
    }
}
