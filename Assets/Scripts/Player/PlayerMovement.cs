using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move
    [HideInInspector]
    public float horizontalMove;
    [HideInInspector]
    public float verticalMove;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public Vector2 lastMovementVect;

    public Animator anim;

    // Ref
    private Rigidbody2D rb;
    private PlayerStats player;
    private bool isMoving;

    void Start()
    {
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovementVect = new Vector2(1, 0f); // Create momentum for the knife on start
    }

    void Update()
    {
        // Input
        InputManage();

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetBool("isMoving", isMoving); // Set the "isMoving" parameter of the animator
    }

    private void FixedUpdate()
    {
        // Movement
        Movement();
    }

    void InputManage()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        direction = new Vector2(xMove, yMove).normalized;

        if (direction.x != 0)
        {
            horizontalMove = direction.x;
            lastMovementVect = new Vector2(horizontalMove, 0f); // Last x Movement
        }

        if (direction.y != 0)
        {
            verticalMove = direction.y;
            lastMovementVect = new Vector2(0f, verticalMove); // Last y Movement
        }

        if (direction.x != 0 && direction.y != 0)
        {
            lastMovementVect = new Vector2(horizontalMove, verticalMove); // While moving
        }

        isMoving = direction != Vector2.zero; // Set isMoving based on the direction
    }

    void Movement()
    {
        rb.velocity = new Vector2(direction.x * player.currentMovementSpeed, direction.y * player.currentMovementSpeed);
    }
}