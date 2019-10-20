using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    GameObject Father;
    [SerializeField]
    string message;
    [SerializeField]
    int parameter;


    void ResetCollider()
    {
        Destroy(GetComponent<BoxCollider2D>());
        gameObject.AddComponent<BoxCollider2D>();
        
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);

    }

    void OnMouseDown()
    {
        if(parameter != 10)
        {
            Father.SendMessage(message, parameter);
        }
        else
        {
            Father.SendMessage(message);
        }
        
    }
}
