using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] bool isPaused;

    [Header("Player")]
    [SerializeField] PlayerAnim playerAnim;
    [SerializeField] float changeTime;
    [SerializeField] bool isGrowUp;
    [SerializeField] bool isFlower;

    public static GameController instance;

    public bool IsPaused { get => isPaused; }
    public bool IsGrowUp { get => isGrowUp; }
    public bool IsFlower { get => isFlower; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    public void GrowUp()
    {
        isGrowUp = true;
        StartCoroutine(ChangePlayer(0, 1));
    }

    public void Flower()
    {
        if(isGrowUp)
        {
            StartCoroutine(ChangePlayer(1, 2));
        }
        else
        {
            StartCoroutine(ChangePlayer(0, 2));
        }
        isGrowUp = true;
        isFlower = true;
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
