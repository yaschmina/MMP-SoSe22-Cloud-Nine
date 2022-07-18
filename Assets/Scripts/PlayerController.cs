using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float moveHorizontal;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float force = 14f;
    [SerializeField] private LayerMask ground; // Ganze Ebene

    private enum StateOfMovement { standing, running, jumping, falling, fallingFront } // standing = idle


    // Start is called before the first frame update
    private void Start()
    {
        // Debug.Log("Hello World!");
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        // Horizontal movement
        //float moveHorizontal = Input.GetAxisRaw("Horizontal"); //hier könnte man auch GetAxisRaw (nicht nur GetAxis) machen -> Player slided nicht mehr mit rest der Geschwindigkeit
        //Vector2 movement = new Vector2(moveHorizontal, 0f);
        //rigidbody2D.AddForce(movement * speed * 3);
    }

    private void Update()
    {
        // Horizontal movement
        moveHorizontal = Input.GetAxisRaw("Horizontal"); //hier könnte man auch GetAxisRaw (nicht nur GetAxis) machen -> Player slided nicht mehr mit rest der Geschwindigkeit
        rigidbody2D.velocity = new Vector2(moveHorizontal * speed, rigidbody2D.velocity.y);

        // Alternative aus Vorlesung:
        // Vector2 movement = new Vector2(moveHorizontal, 0f);
        // rigidbody2D.AddForce(movement * speed * 1);

        // Jump - up and W key (wenn Player am Boden ist)
        if (Input.GetButtonDown("Jump") && PlayerIsOnTheGround())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, force);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation() //im tutorial UpdateAnimationState
    {
        StateOfMovement movementState;

        // Anzeigen der verschiedenen-Sprites
        if (moveHorizontal > 0f) // Rennen nach rechts
        {
            movementState = StateOfMovement.running;
            spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < 0f) // Rennen nach links
        {
            movementState = StateOfMovement.running;
            spriteRenderer.flipX = true;
        }
        else // Stehen
        {
            movementState = StateOfMovement.standing;
        }

        if (rigidbody2D.velocity.y > .1f) // Springen (Wert ist nie genau 0, deswegen .1f)
        {
            movementState = StateOfMovement.jumping;
        }
        else if (rigidbody2D.velocity.y < -.1f) // Fallen
        {
            if (moveHorizontal != 0f)
            {
                movementState = StateOfMovement.falling;
            }
            else // Fallen und Player schaut nach vorne
            {
                movementState = StateOfMovement.fallingFront;
            }
        }

        animator.SetInteger("movementState", (int)movementState);
    }

    private bool PlayerIsOnTheGround() // im Tutorial: IsGrounded
    {
        // eine zweite Box wird über dem Collider erzeugt (ersten zwei Argumente), bei der zweiten Box wird geschaut, ob sie sich mit irgendwas überschneidet (Boden)
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, ground); // schaut, ob player den Boden berührt
        
    }

}
