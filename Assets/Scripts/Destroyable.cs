using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    protected void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }

}
