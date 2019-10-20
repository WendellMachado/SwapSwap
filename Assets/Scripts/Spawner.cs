using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Resetables
{
    [SerializeField]
    GameObject[] spawnPoints;

    [SerializeField]
    GameObject orangeRect, redRect, target;

    [SerializeField]
    Score score;

    [SerializeField]
    float cooldownIn, rectSpeedIn, minimumCooldown, maxRectSpeed, speedFactor, cooldownFactor, cooldownMod, speedMod;

    float cooldown, rectSpeed;

    [SerializeField]
    int maxRandom, jackpot;

    int rectsOnScreen;

    /*void Start()
    {
        Reset();
    }*/

    public override void Reset()
    {
        rectsOnScreen = 0;
        cooldown = cooldownIn;
        rectSpeed = rectSpeedIn;
        StartCoroutine(Spawn());
    }
    
    public int RectsOnScreen
    {
        get { return rectsOnScreen; }
        set { rectsOnScreen = value; }
    }

    void InstantiateRect(GameObject rect)
    {
        int random = Mathf.FloorToInt(Random.Range(0, spawnPoints.Length));
        GameObject newRect = (GameObject)Instantiate(rect, spawnPoints[random].transform.position, rect.transform.rotation);
        this.transform.parent.GetComponent<Scene>().AddDestroyable(newRect);
        newRect.transform.parent = this.transform;
        newRect.GetComponent<Rect>().target = this.target;
        newRect.GetComponent<Rect>().Speed = this.rectSpeed;
        rectsOnScreen++;
    }

    public void Escalate()
    {
        if(score.AddScore % speedMod == 0)
        {
            if (rectSpeed < maxRectSpeed) { rectSpeed += speedFactor; }
            if (rectSpeed > maxRectSpeed) { rectSpeed = maxRectSpeed; }
        }
        if(score.AddScore % cooldownMod == 0)
        {
            if (cooldown > minimumCooldown) { cooldown -= cooldownFactor; }
            if (cooldown < minimumCooldown) { cooldown = minimumCooldown; }
        }
        //print(cooldown + "    " + rectSpeed);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        if(rectsOnScreen < 4)
        {
            int test = Mathf.FloorToInt(Random.Range(0, maxRandom));
            if(test != jackpot)
            {
                InstantiateRect(orangeRect);
            }
            else
            {
                InstantiateRect(redRect);
            }
        }
        StartCoroutine(Spawn());

    }
}
