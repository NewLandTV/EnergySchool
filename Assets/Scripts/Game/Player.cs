using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 moveDirection;

    // Require components.
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;

    private int animatorMoveBool;

    private void Awake()
    {
        animatorMoveBool = Animator.StringToHash("Move");
    }

    private IEnumerator Start()
    {
        while (true)
        {
            Move();

            yield return null;
        }
    }

    public void SetDirection(float directionX)
    {
        moveDirection = new Vector3(directionX, 0f, 0f);
    }

    private void Move()
    {
        spriteRenderer.flipX = moveDirection.x > 0f ? true : moveDirection.x < 0f ? false : spriteRenderer.flipX;

        animator.SetBool(animatorMoveBool, moveDirection.x != 0f);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
