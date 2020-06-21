using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Move(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
