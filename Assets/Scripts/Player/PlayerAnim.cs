using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // References
    Animator anim;
    PlayerMovement moveAnim;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponent<Animator>();
        moveAnim = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xInput = moveAnim.direction.x;
        float yInput = moveAnim.direction.y;

        if (xInput != 0 || yInput != 0)
        {
            anim.SetBool("Move", true);
            SpriteDirCheck(xInput, yInput);
        }
        else
        {
            anim.SetBool("Move", false);
            if (Mathf.Abs(yInput) > Mathf.Abs(xInput))
            {
                anim.SetBool("Side", false);
                anim.SetBool("Front", yInput < 0);
            }
            else
            {
                anim.SetBool("Side", false);
                anim.SetBool("Front", false);
            }
        }
    }

    void SpriteDirCheck(float xInput, float yInput)
    {
        if (Mathf.Abs(xInput) > Mathf.Abs(yInput))
        {
            anim.SetBool("Side", true);
            anim.SetBool("Front", false);
            spriteRenderer.flipX = xInput < 0;
        }
        else if (Mathf.Abs(yInput) > Mathf.Abs(xInput))
        {
            anim.SetBool("Front", true);
            anim.SetBool("Side", false);
            spriteRenderer.flipX = false;
        }
    }
}