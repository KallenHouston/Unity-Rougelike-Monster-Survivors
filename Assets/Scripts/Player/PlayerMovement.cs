using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Move
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float horizontalMove;
    [HideInInspector]
    public float verticalMove;
    [HideInInspector]
    public Vector2 direction;
    public Vector2 lastMovementVect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovementVect = new Vector2(1, 0f); //create momentum for the knife on start
    }

    void Update()
    {
        InputManage();
    }

    private void FixedUpdate()
    {
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
            lastMovementVect = new Vector2(horizontalMove, 0f); //Last x Movement
        }

        if(direction.y != 0)
        {
            verticalMove = direction.y;
            lastMovementVect = new Vector2(0f, verticalMove); //Last y Movement
        }

        if(direction.x != 0 && direction.y != 0)
        {
            lastMovementVect = new Vector2(horizontalMove, verticalMove); //while moving
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
