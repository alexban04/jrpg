using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    [SerializeField] float maxBattleChance;
    float battleChance;
    [SerializeField] float battleChanceGrowth;

    private float currentSpeed;
    private UnityEngine.Vector3 input;
    private UnityEngine.Vector3 lastInput;
    private bool facingRight;
    private bool isMoving;
    private Animator animator;

    public UnityEngine.LayerMask solidObjectsLayer;
    public UnityEngine.LayerMask interactablesLayer;
    public UnityEngine.LayerMask battleLayer;

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
            checkForEncounters();
        }
        else
        {
            currentSpeed -= acceleration;
            isMoving = false;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed);
        if (currentSpeed != 0)
        {
            battleChance += battleChanceGrowth;
            battleChance = Mathf.Clamp(battleChance, 0, maxBattleChance);
        }
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
        var collider = Physics2D.OverlapCircle(transform.position, 1f, interactablesLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
    private void checkForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.01f, battleLayer) != null)
        {
            if (Random.Range(1, 100) <= battleChance)
            {
                Debug.Log("Start Battle");
                SceneManager.LoadScene(1);
                battleChance = 0;
            }
        }
    }
}
