using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Resetables
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Score score;

    [SerializeField]
    GooglePlayer googlePlayer;

    [SerializeField]
    static int swap;

    #region GETS & SETS

    public Score Score
    {
        get { return score; }
    }

    #endregion

    public override void Reset()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 45);
        swap = 0;
    }

    void Swap()
    {
        if (swap == 3) { swap = 2; }
        if (swap == 0) { swap = 1; }
        this.animator.SetInteger("Swap", swap);
    }

    void ResetSwap(int nextSwap)
    {
        swap = nextSwap;
    }

    void GameOver()
    {
        this.googlePlayer.PostScore(score.AddScore);
        this.googlePlayer.Achievements(score.AddScore);
        this.transform.parent.GetComponent<Scene>().CallScene(2);
    }

}
