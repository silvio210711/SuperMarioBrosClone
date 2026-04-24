using System;
using UnityEngine;

public class Playeranim : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       ChangeAnimation(); 
    }

    void ChangeAnimation()
    {
        if (InputManager.Instance.IsJumping)
        {
            anim.SetInteger("Transition",2);
            
        }
        else
        {
            if(InputManager.Instance.GetMovimentInput().x == 0)
            {
                anim.SetInteger("Transition",0);
            }
            else
            {
               anim.SetInteger("Transition",1); 
            }

        }
    }
}
