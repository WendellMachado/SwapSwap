using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAdmin : MonoBehaviour
{
    [SerializeField]
    GameObject[] Scenes;

    public void ChangeScene(int actualScene, int nextScene)
    {
        Scenes[actualScene].GetComponent<Scene>().CallAnimatorFades("FadeOut");
        Scenes[actualScene].GetComponent<Scene>().DestroyDestroyables();
        Scenes[actualScene].GetComponent<Scene>().ObjectActivation(false);
        Scenes[nextScene].GetComponent<Scene>().ObjectActivation(true);
        Scenes[nextScene].GetComponent<Scene>().CallAnimatorFades("FadeIn");
        Scenes[nextScene].GetComponent<Scene>().ResetResetables();
    }
}
