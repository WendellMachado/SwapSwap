using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    Animator scoreAnimator;
    Score score;

    void Start()
    {
        this.score = this.transform.parent.GetComponent<Player>().Score;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag(this.gameObject.tag))
        {
            this.transform.parent.GetComponent<SoundHandler>().Play(0);
            this.scoreAnimator.SetTrigger("Shake");
            this.score.AddScore = 1;
            this.transform.parent.transform.parent.transform.parent.GetComponent<GooglePlayer>().Achievements(this.score.AddScore);
            c.gameObject.GetComponent<Rect>().Die();
        }
        else if(c.gameObject.tag.Equals("Bt"))
        {

        }
        else if(c.gameObject.tag.Equals("Orange") || c.gameObject.tag.Equals("Red"))
        {
            this.transform.parent.GetComponent<SoundHandler>().Play(1);
            c.gameObject.GetComponent<Rect>().Die();
            this.transform.parent.GetComponent<Animator>().SetTrigger("Destroy");
        }
    }
    
}
