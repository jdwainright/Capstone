using UnityEngine;
using System.Collections;


public class CharacterController_Capstone : MonoBehaviour 
{
	public float maxSpeed = 5f;
	public bool facingRight = true;
	
	Animator anim;
	
	bool grounded = false;
	//bool touchingWall = false; 
	//bool touchingWall_2 = false;
	public Transform groundCheck;
	//public Transform wallCheck;
	//public Transform wallCheck_2;
	float groundRadius = 1f;
	//float wallTouchRadius = 0.2f;
	public LayerMask whatIsGround;
	//public LayerMask whatIsWall;
	public float jumpForce = 3000f;
//	public float jumpPushForce = 100f;
	
	//public float teleportDistance = 5f;
	//public float temp;
	
	bool doubleJump = false;
	
	//public Rigidbody2D projectile;
	//public float fireRate;
	//private float canFireIn;
	//public Transform throwLocation;
	
	
	void awake ()
	{
		
		//Rigidbody rb = GetComponent<Rigidbody> ();
	}
	
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () 
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
//		touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallTouchRadius, whatIsWall);
//		touchingWall_2 = Physics2D.OverlapCircle(wallCheck_2.position, wallTouchRadius, whatIsWall);
		
		if (grounded)
			doubleJump = false;
		
//		if (touchingWall) 
//		{
//			grounded = false; 
//			doubleJump = false; 
//		}
		
		//anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat ("Speed", Mathf.Abs (move));
		print (move);
		
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (move > 0 && !facingRight)
			flip ();
		else if (move < 0 && facingRight)
			flip ();
	}
	
	void Update()
	{
//		canFireIn -= Time.deltaTime;
//		anim.SetBool ("Teleport", false);
//		anim.SetBool ("Throw", false);
		if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			anim.SetBool ("Ground", true);
			
			if (!doubleJump && !grounded)
				doubleJump = true;
			
			
		}
		
//		if (Input.GetKeyDown (KeyCode.LeftShift))
//		{
//			anim.SetBool ("Teleport", true);
//			if (facingRight)
//				flip ();
//			
//			transform.position = new Vector3(transform.position.x-teleportDistance, transform.position.y, 0);
//			//anim.SetBool ("Teleport", false); // might not need this
//		}
//		if (Input.GetKeyDown (KeyCode.RightShift))
//		{
//			anim.SetBool ("Teleport", true);
//			if (!facingRight)
//				flip ();
//			
//			transform.position = new Vector3(transform.position.x+teleportDistance, transform.position.y, 0);
//			//anim.SetBool ("Teleport", false); // might not need this
//		}
		
//		if ((touchingWall || touchingWall_2) && Input.GetKeyDown (KeyCode.Space)) 
//		{
//			GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
//			GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 200f));
//		}
//		
//		if (Input.GetKeyDown (KeyCode.Z) && canFireIn <= 0)
//		{
//			anim.SetBool("Throw", true);
//			fireProjectile();
//		}
	}
	
//	void fireProjectile()
//	{
//		if (canFireIn > 0)
//			return;
//		
//		var direction = facingRight ? Vector2.right : -Vector2.right;
//		Rigidbody2D projectileSpawn = Instantiate (projectile, throwLocation.position, throwLocation.rotation) as Rigidbody2D;
//		canFireIn = fireRate;
//	}
	
	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{ 
		if (coll.gameObject.tag.Equals("Enemy"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}

