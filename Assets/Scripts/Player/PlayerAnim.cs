using System;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] int layerWeight;
    [SerializeField] BoxCollider2D littleCollider;
    [SerializeField] BoxCollider2D bigCollider;
    Animator anim;

    public int LayerWeight { get => layerWeight; set => layerWeight = value; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.IsPaused)
        {
            ChangeAnimation();
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }
        ChangeLayer();
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

    void ChangeLayer()
    {
        ChangeCollider(layerWeight);
        if(layerWeight == 0)
        {            
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(2, 0);
        }
        else if(layerWeight == 1)
        {
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(2, 0);
        }
        else if(layerWeight == 2)
        {
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(2, 1);
        }
    }
    void ChangeCollider(int collider)
    {
        if(collider == 0)
        {
            littleCollider.enabled = true;
            bigCollider.enabled = false;
        }
        else
        {
            littleCollider.enabled = false;
            bigCollider.enabled = true;
        }
    }
}
