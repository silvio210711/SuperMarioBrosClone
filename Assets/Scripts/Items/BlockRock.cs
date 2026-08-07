using UnityEngine;

public class BlockRock : MonoBehaviour
{
    [SerializeField] GameObject PieceLeftDown;
    [SerializeField] GameObject PieceLeftUp;
    [SerializeField] GameObject PieceRightDown;
    [SerializeField] GameObject PieceRightUp;
    [SerializeField] float rockImpulse;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerHead"))
        {
            if (!GameController.instance.IsGrowUp)
            {
                anim.SetTrigger("Hit");
            }
            else
            {
                SpawnPiece(PieceRightUp, new Vector2(rockImpulse / 2, rockImpulse));
                SpawnPiece(PieceLeftUp, new Vector2(-rockImpulse / 2, rockImpulse));
                SpawnPiece(PieceRightDown, new Vector2(rockImpulse / 2, rockImpulse / 2));
                SpawnPiece(PieceLeftDown, new Vector2(-rockImpulse / 2, rockImpulse / 2));
                Destroy(gameObject, 0.1f);
            }
        }
    }

    void SpawnPiece(GameObject piece, Vector2 force)
    {
        GameObject rock = Instantiate(piece, transform.position, transform.rotation);
        rock.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
