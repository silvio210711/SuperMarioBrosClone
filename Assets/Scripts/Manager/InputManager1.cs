using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class InputManager : MonoBehaviour
{
    [SerializeField] bool jumpPressed;
    [SerializeField] bool jumpReleased;
    [SerializeField] bool isJumping;
    Vector2 movimentInput;
    public static InputManager Instance;

    public bool JumpPressed {get => jumpPressed; set => jumpPressed = value;}

    public bool JumpReleased {get => jumpReleased; set => jumpReleased = value;}
    public bool IsJumping {get => isJumping; set => isJumping = value;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void OnMove(InputValue value)
    {
        movimentInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    { 
        if(value.isPressed && !isJumping)
        {
            JumpPressed = true;
            JumpReleased = false;
        }
        else
        {
            JumpReleased = true;
        }
    }
        
    public Vector2 GetMovimentInput()
    {
        return Instance.movimentInput;
    }
}

