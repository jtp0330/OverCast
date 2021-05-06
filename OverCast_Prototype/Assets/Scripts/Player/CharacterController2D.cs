using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float speed = 40;
	[SerializeField] private float jumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool airControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform ceilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f;				// Radius of the overlap circle to determine if grounded
	[SerializeField] private bool isGrounded;       // Whether or not the player is grounded.
	[SerializeField] private bool isMoving;			// Whether or not the player is moving
	const float k_CeilingRadius = .2f;				// Radius of the overlap circle to determine if the player can stand up
	private bool m_FacingRight = true;				// For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private Rigidbody2D rigidbody2D;
	private float horizontalInput;
	private bool jumpInput;
    public AudioManager am;

	private Animator animator;
    //added variable for double jump mechanic 
    private bool canDoubleJump;
	

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;



	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void Update()
	{
		GetPlayerInput();
	
		AnimatePlayer(horizontalInput);
	}

	private void FixedUpdate()
	{
		Move(horizontalInput * Time.fixedDeltaTime, false);

		if (jumpInput)
            Jump(jumpInput);
		else CheckForGround();
		
		jumpInput = false;
	}

	private void GetPlayerInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal") * speed;

		if (Input.GetButtonDown("Jump")) jumpInput = true;

		
	}

	public void Move(float move, bool crouch)
	{


        //only control the player if grounded or airControl is turned on
        if (isGrounded || airControl)
        {

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

	}
    //incorporate double jump
	private void Jump(bool jump)
	{
        Vector2 jumps = new Vector2(0f, jumpForce);
        // If the player should jump...
        if (isGrounded && jump)
        {
            // Add a vertical force to the player.
            am.getJumps().Play();
            isGrounded = false;
            canDoubleJump = true;
            rigidbody2D.AddForce(jumps);
            animator.SetTrigger("Move&Jump");
        }else if(canDoubleJump)
        {
            am.getJumps().Play();
            isGrounded = false;
            canDoubleJump = false;
            rigidbody2D.AddForce(jumps);
            animator.SetTrigger("Move&Jump");
        }
	}

	private void AnimatePlayer(float move)
	{
		animator.SetFloat("Speed", Mathf.Abs(move));
		//animator.SetBool("IsJumping", !isGrounded);
	}

	private void CheckForGround()
	{
		bool wasGrounded = isGrounded;
		isGrounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180, 0f);
	}

}
