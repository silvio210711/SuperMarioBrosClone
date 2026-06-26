using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundChek;
    [SerializeField] float radius = 0.2f;

    [SerializeField] GameObject headLittleMario;
    [SerializeField] GameObject headBigMario;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();        
    }

    void CheckCollision()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChek.position,radius,groundLayer);
        InputManager.Instance.IsJumping = !isGrounded;
        Debug.DrawRay(groundChek.position, Vector2.down * radius, Color.red);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mushroom"))
        { 
            if(!GameController.instance.IsGrowUp)
            {
               GameController.instance.GrowUp(); 
            }
            headLittleMario.SetActive(false);
            headBigMario.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Flower"))
        { 
            if(!GameController.instance.IsFlower)
            {
               GameController.instance.Flower(); 
            }
            headLittleMario.SetActive(false);
            headBigMario.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
