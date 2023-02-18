using UnityEngine;

namespace ZD5Project2D.Player
{
	public class PlayerMovement : MonoBehaviour
    {
        // TODO: move that consts to other class
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string SPRINT_AXIS = "Sprint";
        public const string JUMP_AXIS = "Jump";

        [SerializeField]
        private Rigidbody2D rigidbody2D;

        [SerializeField]
        private float moveSpeed = 7;

        [SerializeField]
        private float maxWalkSpeed = 5;

        [SerializeField]
        private float sprintBoost = 1.5f;

        [SerializeField]
        private float maxSprintSpeed = 10;

        [SerializeField]
        private float jumpForce = 7;

        [SerializeField]
        private float maxJumpSpeed = 2;

        [SerializeField]
        private int jumpsAmount = 2;

        [SerializeField]
        private Collider2D collider2D;

        [SerializeField]
        private CameraController camera;

        [SerializeField]
        private float cameraRaycastRange = 7.0f;

        [SerializeField]
        private SpriteRenderer sprite;

        private float moveInput;
        private float sprintInput;
        private int jumpsLeft;
        private float jumpInput;
        private bool isJumpButtonClicked;
        private int faceDirection = 1;

        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void UpdatePosition()
        {
            moveInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
            sprintInput = Input.GetAxisRaw(SPRINT_AXIS);
            jumpInput = Input.GetAxisRaw(JUMP_AXIS);

            if (jumpInput == 0)
                isJumpButtonClicked = false;

            if (jumpInput > 0 && !isJumpButtonClicked)
            {
                isJumpButtonClicked = true;
                Jump();
            }
        }

        public void FixedUpdatePosition()
        {
            HorizontalMovement();
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void HorizontalMovement()
        {
            float playerMovement = moveInput * moveSpeed;

            if (sprintInput > 0)
            {
                playerMovement *= sprintBoost;
            }

            rigidbody2D.AddForce(Vector2.right * playerMovement, ForceMode2D.Force);

            var x = rigidbody2D.velocity.x;
            var direction = Mathf.Sign(x);
            x = Mathf.Abs(x);

            if (sprintInput == 0)
            {
                x = Mathf.Clamp(x, 0, maxWalkSpeed);
            }
            else
            {
                x = Mathf.Clamp(x, 0, maxSprintSpeed);
            }

            Vector2 finalVelocity = new Vector2(x * direction, rigidbody2D.velocity.y);
            rigidbody2D.velocity = finalVelocity;

            if(faceDirection == direction)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }

            RaycastHit2D cameraRaycast = Physics2D.Raycast(rigidbody2D.position, Vector2.right * direction, cameraRaycastRange, 1 << 7);
            Debug.DrawRay(rigidbody2D.position, Vector2.right * direction * 5, Color.red);

            if(cameraRaycast.collider != null)
            {
                if(moveInput == 0)
                {
                    //StopMovement();
                    camera.UpdateMovement(Vector2.zero, transform.position.y);
                }
                else
                {
                    camera.UpdateMovement(rigidbody2D.velocity, transform.position.y);
                }
            }
            else
            {
                //StopMovement();
                camera.UpdateMovement(Vector2.zero, transform.position.y);
            }
        }

        public void Jump()
        {
            RaycastHit2D boxCastHit = Physics2D.BoxCast(rigidbody2D.position, rigidbody2D.transform.localScale, 0, Vector2.down, 0.1f);

            if (boxCastHit.collider != null && boxCastHit.collider.CompareTag("Ground"))
            {
                jumpsLeft = jumpsAmount;
            }

            if(jumpsLeft > 0)
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                jumpsLeft--;
            }

            var y = rigidbody2D.velocity.y;
            var direction = Mathf.Sign(y);
            y = Mathf.Abs(y);
            y = Mathf.Clamp(y, 0, maxJumpSpeed);

            Vector2 finalVelocity = new Vector2(rigidbody2D.velocity.x, y * direction);
            rigidbody2D.velocity = finalVelocity;
        }
    } 
}
