using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : Resetables
{
    [SerializeField]
    Text scoreText;
    int score;

    public override void Reset()
    {
        this.score = 0;
        scoreText.text = score.ToString();
    }

    public int AddScore
    {
        get { return score; }
        set { score += value; scoreText.text = score.ToString(); }
    }
	
}
