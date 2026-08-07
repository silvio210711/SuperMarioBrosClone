using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform player;
    public float limit;

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > transform.position.x && player.position.x < limit)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
