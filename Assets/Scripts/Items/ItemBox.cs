using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] bool isQuestionBox;
    [SerializeField] bool isContinuosItems;

    [SerializeField] bool isStarted;
    [SerializeField] float hitTime;
    [SerializeField] bool isHitted;

    [SerializeField] GameObject [] items;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Transition", isQuestionBox ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted && hitTime > 0)
        {
            hitTime -= Time.deltaTime;
        }

        if(hitTime<=0)
        {
            isContinuosItems = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "PlayerHead" && !isHitted)
        {
            if (!isContinuosItems)
            {
                anim.SetTrigger("Hit");
                isHitted = true;
                if(items.Length == 1)
                {
                    GameObject item = Instantiate(items[0], transform.position, transform. rotation);
                }
                else if(items.Length == 2)
                {
                    if(!GameController.instance.IsGrowUp)
                    {
                        GameObject item = Instantiate(items[0], transform.position, transform.rotation);
                        
                    }
                    else
                    {
                        GameObject item = Instantiate(items[1], transform.position, transform.rotation);
                    }
                }
            }
            else
            {
                anim.SetTrigger("ContinuosHit");
                isStarted = true;
                GameObject item = Instantiate(items[0], transform.position, transform.rotation);
            }
        }  
    }
}
