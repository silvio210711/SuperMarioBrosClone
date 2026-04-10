using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Vector2 movimentInput;
    public static InputManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void OnMove(InputValue value)
    {
        movimentInput = value.Get<Vector2>();
    }
        
    public Vector2 GetMovimentInput()
    {
        return Instance.movimentInput;
    }
}

