using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundChek;
    [SerializeField] float radius = 0.2f;
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
}
