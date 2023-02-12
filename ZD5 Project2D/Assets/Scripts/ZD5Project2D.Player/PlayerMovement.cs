using UnityEngine;

namespace ZD5Project2D.Player
{
	public class PlayerMovement : MonoBehaviour
    {
        // TODO: move that const to other class
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string SPRINT_AXIS = "Sprint";

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
        private float jumpForce = 5;

        [SerializeField]
        private int jumpsAmount = 2;

        [SerializeField]
        private Collider2D collider2D;

        private float moveInput;
        private float sprintInput;
        private float scaleX;
        private int jumpsLeft;
        private bool isGrounded;

        public void Init()
        {
            gameObject.SetActive(true);
            scaleX = transform.localScale.x;
            // set start position
        }

        public void UpdatePosition()
        {
            moveInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
            sprintInput = Input.GetAxisRaw(SPRINT_AXIS);
            Jump();
        }

        public void FixedUpdatePosition()
        {
            float playerMovement = moveInput * moveSpeed;

            if(sprintInput > 0)
            {
                playerMovement *= sprintBoost;
            }
            
            rigidbody2D.AddForce(Vector2.right * playerMovement, ForceMode2D.Force);

            var x = rigidbody2D.velocity.x;
            var direction = Mathf.Sign(x);
            x = Mathf.Abs(x);

            if(sprintInput == 0)
            {
                x = Mathf.Clamp(x, 0, maxWalkSpeed);
            }
            else
            {
                x = Mathf.Clamp(x, 0, maxSprintSpeed);
            }

            Vector2 finalVelocity = new Vector2(x * direction, rigidbody2D.velocity.y);
            rigidbody2D.velocity = finalVelocity;
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(jumpsLeft > 0)
                {
                    rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    jumpsLeft--;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
                ResetJumps();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }

        public void ResetJumps()
        {
            if(isGrounded)
            {
                jumpsLeft = jumpsAmount - 1;
            }
        }
    } 
}
