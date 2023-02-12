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
        private float sprintBoost = 1.5f;

        [SerializeField]
        private float jumpForce = 5;

        [SerializeField]
        private int jumpsAmount = 2;

        [SerializeField]
        private Transform GroundCheck;

        [SerializeField]
        private LayerMask GroundLayer;

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
            if(sprintInput > 0)
            {
                rigidbody2D.AddForce(Vector2.right * (moveInput * sprintBoost * moveSpeed), ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.AddForce(Vector2.right * (moveInput * moveSpeed), ForceMode2D.Force);
            }
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckIfGrounded();
                if(jumpsLeft > 0)
                {
                    rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    jumpsLeft--;
                }
            }
        }

        public void CheckIfGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
            ResetJumps();
        }

        public void ResetJumps()
        {
            if(isGrounded)
            {
                jumpsLeft = jumpsAmount;
            }
        }
    } 
}
