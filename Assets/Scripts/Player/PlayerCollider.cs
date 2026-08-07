using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
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
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);

        InputManager.instance.IsJumping = !isGrounded;

        Debug.DrawRay(groundCheck.position, Vector2.down * radius, Color.red);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mushroom"))
        {
            if(!GameController.instance.IsGrowUp)
            {
                GameController.instance.GrowUp();
            }
            headLittleMario.SetActive(false);
            headBigMario.SetActive(true);
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Flower"))
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
