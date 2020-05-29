using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue06 : Enemy
{
    private Vector3 currentTarget;
    private Animator anim;
    private SpriteRenderer[] sprites;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Rogue_idle_01"))
        {
            return;
        }

        movement();
    }

    void movement()
    {
        if (currentTarget == pointA.position && transform.rotation.eulerAngles.y == 0)
        {
            // rogueSprite.flipX = true;
            //transform.rotation = new Vector3(0, 180, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);

        }
        else if (currentTarget == pointB.position && transform.rotation.eulerAngles.y == 180)
        {
            //rogueSprite.flipX = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }
}
