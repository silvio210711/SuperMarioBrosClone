using System;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] PlayerController player;
    public float limit;
    
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x && transform.position.x < limit)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
