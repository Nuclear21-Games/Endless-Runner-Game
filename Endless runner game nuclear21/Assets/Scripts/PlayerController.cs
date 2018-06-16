using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreasMilestone;
	private float speedIncreasMilstoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float JumpTime;
	private float JumpTimeCounter;

	private bool stoppedjumping;
	private bool canDoubleJump;

	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform GroundCheck;
	public float GroundCheckRadius;

	//private Collider2D myCollider;


	private Animator myAnimator;

	public GameManager theGameManager;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();

		//myCollider = GetComponent<Collider2D>();

		myAnimator = GetComponent<Animator>();

		JumpTimeCounter = JumpTime;

		speedMilestoneCount = speedIncreasMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreasMilstoneStore = speedIncreasMilestone;

		stoppedjumping = true;
	}

	// Update is called once per frame
	void Update() {

		//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreasMilestone;

			speedIncreasMilestone = speedIncreasMilestone * speedMultiplier;

			moveSpeed = moveSpeed * speedMultiplier;

		}

		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))

		{
			if (grounded)
			{ 
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);

				stoppedjumping = false;
			}

			if(!grounded && canDoubleJump)
			{
				
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				JumpTimeCounter = JumpTime;
				stoppedjumping = false;
				canDoubleJump = false;
			}

		}


		if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedjumping)
		{
			if(JumpTimeCounter > 0)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				JumpTimeCounter -=Time.deltaTime;
			}
		}
		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0) )
		{
			JumpTimeCounter = 0;
			stoppedjumping = true;
		}

		if(grounded)
		{
			JumpTimeCounter = JumpTime;
			canDoubleJump = true;
		}
		
		myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool("Grounded", grounded);

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox")
		{
			
			theGameManager.RestartGame();
             moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreasMilestone = speedIncreasMilstoneStore;
		}
	}

}
