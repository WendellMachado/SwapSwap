using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rect : Destroyable
{
    public GameObject target;

    [SerializeField]
    Rigidbody2D rigidbody;

    protected Vector2 initialPos;
    protected Vector2 direction;

    static float speed;

    protected float travelledPath;

    void Start ()
    {
        this.initialPos = this.transform.position;
        SetDirection();
	}

    void SetDirection()
    {
        if (initialPos.x > 0 && initialPos.y > 0) { direction = new Vector2(-1, -1); }
        if(initialPos.x < 0 && initialPos.y < 0) { direction = new Vector2(1, 1); }

        if(initialPos.x > 0 && initialPos.y < 0) { direction = new Vector2(-1, 1); }
        if (initialPos.x < 0 && initialPos.y > 0) { direction = new Vector2(1, -1); }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void Die()
    {
        this.transform.parent.GetComponent<Spawner>().RectsOnScreen--;
        this.transform.parent.GetComponent<Spawner>().Escalate();
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().SetTrigger("Die");
    }

	void FixedUpdate ()
    {
        Move();
	}

    protected void Move()
    {
        this.rigidbody.velocity = direction * speed * (Time.deltaTime * 60);
    }

   /* protected void Move()
    {
        travelledPath += speed * (Time.deltaTime * 60);
        this.transform.position = Vector2.Lerp(this.initialPos, this.target.transform.position, this.travelledPath);
    }*/
}
