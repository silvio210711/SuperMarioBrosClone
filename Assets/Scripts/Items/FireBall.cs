using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class FireBall : MonoBehaviour
{
    [Header("Moviment Settings")]
    [SerializeField] float speed;
    [SerializeField] float force;
    [SerializeField] float direction;

    [Header("Raycast Settings")]
    [SerializeField] float downRayLength = 0.3f;
    [SerializeField] float ForwardRayLength = 0.3f;
    [SerializeField] LayerMask groundLayer;

    bool hit;
    Animator anim;
    Rigidbody2D rig;

    public float Direction { get => direction; set => direction = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            rig.linearVelocity = new Vector2(speed * direction, rig.linearVelocity.y);

            CheckRaycasts();
        }
    }

    void CheckRaycasts()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, downRayLength, groundLayer);

        if(hitDown.collider != null)
        {
            rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0);
            rig.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        Vector2 forwardDirection = direction > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, forwardDirection, ForwardRayLength, groundLayer);

        if(hitForward.collider != null)
        {
            Explode();
        }
    }

    void Explode()
    {
        if(hit) return;

        hit = true;
        rig.linearVelocity = Vector2.zero;
        rig.gravityScale = 0;
        anim.SetTrigger("Hit");

        GetComponent<CircleCollider2D>().enabled = false;

        Destroy(gameObject, 0.125f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
