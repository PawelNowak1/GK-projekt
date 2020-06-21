using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue06 : Enemy, IDamageable
{
    private Vector3 currentTarget;
    private Animator anim;
    private SpriteRenderer[] sprites;

    protected bool isHit = false;
    protected bool isDead = false;
    protected Player player;

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Rogue_idle_01") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        if (isDead == false)
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

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 3.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        } else
        {
            isHit = true;
            anim.SetTrigger("Idle");
            anim.SetBool("InCombat", true);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            //sprite.flipX = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            //sprite.flipX = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Health = base.health;
    }

    public int Health { get; set; }

    public void Damage()
    {
      
        Health--;
        if (Health == 0)
        {
            isDead = true;
            anim.SetTrigger("Death");
        } else if(Health < 1)
        {
            isDead = true;
        } else
        {
            isHit = true;
            anim.SetBool("InCombat", true);
            Debug.Log("Damage");
            anim.SetTrigger("Hit");
        }
    }
}
