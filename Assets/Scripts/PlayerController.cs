using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;

    private float currentSpeed;
    private UnityEngine.Vector3 input;
    private UnityEngine.Vector3 lastInput;
    private bool facingRight;
    private bool isMoving;
    private Animator animator;

    public UnityEngine.LayerMask solidObjectsLayer;
    public UnityEngine.LayerMask interactablesLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        facingRight = true;
        isMoving = false;
    }

    public void HandleUpdate()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        if (input != UnityEngine.Vector3.zero)
        {
            lastInput = input;
            currentSpeed += acceleration;
            isMoving = true;
        }
        else
        {
            currentSpeed -= acceleration;
            isMoving = false;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed);
        if (isWalkable(transform.position + input * currentSpeed))
            transform.position += input * currentSpeed;
        if (input.x > 0 && !facingRight || input.x < 0 && facingRight)
        {
            UnityEngine.Vector2 playerScale = transform.localScale;
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
            facingRight = !facingRight;
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.E)) Interact();
    }
    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactablesLayer) != null) return false;
        return true;
    }
    void Interact()
    {
        Debug.Log("E is pressed");
        var interactPos = transform.position + lastInput * moveSpeed;
        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactablesLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
}
