using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] bool jumpPressed;
    [SerializeField] bool jumpReleased;
    [SerializeField] bool isJumping;
    [SerializeField] bool isFire;
    [SerializeField] bool isFireButtonPressed;
    Vector2 movementInput;

    public static InputManager instance;

    public bool JumpPressed { get => jumpPressed; set => jumpPressed = value; }
    public bool JumpReleased { get => jumpReleased; set => jumpReleased = value; }
    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public bool IsFire { get => isFire; set => isFire = value; }
    public bool IsFireButtonPressed { get => isFireButtonPressed; set => isFireButtonPressed = value; }

    void Awake()
    {
        instance = this;
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
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

    void OnAttack(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("Apertou");
            isFire = true;
        }
        else
        {
            Debug.Log("Soltou");
            isFire = false;
        }
    }
    
    public Vector2 GetMovementInput()
    {
        return instance.movementInput;
    }
}
