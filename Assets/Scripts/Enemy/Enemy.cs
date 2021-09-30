using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 target;
    protected Animator anim;
    protected SpriteRenderer spriteRen;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRen = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim"))
        {
            return;
        }
        Flip();
        Movement();
    }

    public virtual void Movement()
    {
        if (transform.position == pointA.position)
        {
            target = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            target = pointA.position;
            anim.SetTrigger("Idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public virtual void Flip()
    {
        if (target == pointA.position)
        {
            spriteRen.flipX = true;
        }
        else
        {
            spriteRen.flipX = false;
        }
    }
}
