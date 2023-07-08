using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //Ref
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
        if (moveAnim.direction.x != 0 || moveAnim.direction.y != 0)
        {
            anim.SetBool("Move", true);

            SpriteDirCheck();
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    void SpriteDirCheck()
    {
        if (moveAnim.horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
