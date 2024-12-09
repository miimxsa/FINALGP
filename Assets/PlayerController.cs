using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public float collisionOffset = 0.05f; 
    public ContactFilter2D movementFilter; 
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Vector2 movementInput; 
    private SpriteRenderer spriteRenderer; 
    private Rigidbody2D rb; 
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); 

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                // Change sprite based on movement direction
                ChangeSpriteBasedOnMovement();
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction, 
                movementFilter, 
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset); 

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void ChangeSpriteBasedOnMovement()
    {
        if (movementInput.y > 0)
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (movementInput.y < 0) 
        {
            spriteRenderer.sprite = downSprite;
        }
        else if (movementInput.x > 0) 
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (movementInput.x < 0) 
        {
            spriteRenderer.sprite = leftSprite;
        }
    }

    void OnMove(UnityEngine.InputSystem.InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>(); 
		
    }
}
