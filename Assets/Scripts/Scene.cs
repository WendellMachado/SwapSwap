using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] Resetables;
    [SerializeField]
    protected List<Animator> animatorList;
    [SerializeField]
    protected List<GameObject> objectList;

    protected List<GameObject> Destroyables;

    [SerializeField]
    protected SceneAdmin SceneAdmin;
    [SerializeField]
    protected int ID;

    void Start()
    {
        Destroyables = new List<GameObject>();
    }

    public void ResetResetables()
    {
        for(int i = 0; i < Resetables.Length; i++)
        {
            Resetables[i].GetComponent<Resetables>().Reset();
        }
    }

    public void AddDestroyable(GameObject destroyable)
    {
        this.Destroyables.Add(destroyable);
    }

    public void DestroyDestroyables()
    {
        foreach (GameObject destroyable in this.Destroyables)
            GameObject.Destroy(destroyable);
    }

    public void CallScene(int nextScene)
    {
        this.SceneAdmin.ChangeScene(this.ID, nextScene);
    }

    public void ObjectActivation(bool activate)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            objectList[i].SetActive(activate);
        }
    }

    public void CallAnimatorFades(string animTrigger)
    {
        for(int i = 0; i < this.animatorList.Count; i++)
        {
            this.animatorList[i].SetTrigger(animTrigger);
        }
    }
    
}
