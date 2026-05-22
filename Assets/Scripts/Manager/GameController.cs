using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [Header("Player")]
    [SerializeField] float changeTime;
    [SerializeField] PlayerAnim playerAnim;
    [SerializeField] bool isGrowUp;

    public static GameController instance;
     public bool IsGrowUp { get => isGrowUp; }


    public bool IsPaused { get => isPaused; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrowUp()
    {
        isGrowUp = true;
        StartCoroutine(ChangePlayer(0, 1));
    }

    IEnumerator ChangePlayer(int actualPlayer, int nextPlayer)
    {
        isPaused = true;
        playerAnim.LayerWeight = nextPlayer;
        yield return new WaitForSeconds(changeTime);
        playerAnim.LayerWeight = actualPlayer;
        yield return new WaitForSeconds(changeTime);
        playerAnim.LayerWeight = nextPlayer;
        yield return new WaitForSeconds(changeTime);
        playerAnim.LayerWeight = actualPlayer;
        yield return new WaitForSeconds(changeTime);
        playerAnim.LayerWeight = nextPlayer;
        isPaused = false;
    }
}
