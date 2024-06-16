using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 8f;
    private float dirX;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioClip jumpSoundEffect;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    private void Update() {
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            AudioManager.Instance.PlaySoundEffect(jumpSoundEffect);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

    private void FixedUpdate() {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * speed, rb.velocity.y);
        updateAnimationState();
    }

    private void updateAnimationState() {
        MovementState state;

        //Running and idle animation : 
        if(dirX != 0) {
            state = MovementState.running;
            transform.rotation = (dirX > 0) ? Quaternion.identity : Quaternion.Euler(Vector2.up * 180f);
        }

        else {
            state = MovementState.idle;
        }

        //Jumping and Falling animation :
        if(rb.velocity.y > 0.1f) {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -0.1f) {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, -transform.up, 0.1f, jumpableGround);
    }

}
