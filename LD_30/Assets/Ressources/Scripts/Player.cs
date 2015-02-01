using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// Public Variables
	
	public float speed = 3f;
	public float jumpForce = 3f;
	public Rigidbody2D fireball;
	public AudioClip appearSound, airshockSound, hurt, dead, fireballSound,take, tink;
	public GameObject scripts,appearAnimation;
	public bool theOne, apeared, playHurt, playDead, jumping;
	
	//Private Variables
	
	private float nextShot, shotRate, hSpeed, vSpeed;
	private bool moving  = false;
	private bool right, grounded;
	private float jumpRate, nextJump;
	private GameObject air;
	private Animator anim;
		
	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
		this.anim = this.GetComponentInChildren<Animator>();
		this.jumpRate = 1f;
		this.nextJump = 0f;
		this.theOne = false;
		this.apeared = true;
		this.right = true;
		this.playHurt = false;
		this.playDead = false;
		this.vSpeed = this.hSpeed = 0f;
		
		this.shotRate = 1.5f;
		this.nextShot = 0f;
		this.grounded = false;
		this.jumping = false;
		
		air= GameObject.Find("Air");
		air.GetComponent<SpriteRenderer>().active = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Application.loadedLevelName.Equals("splash"))
		{
			
			if (this.playDead)
			{
				AudioSource.PlayClipAtPoint(this.dead, this.transform.position);
				this.playDead = false;
			}
			if (this.playHurt)
			{
				AudioSource.PlayClipAtPoint(this.hurt, this.transform.position);
				this.playHurt = false;
			}
			if(air.GetComponent<SpriteRenderer>().active) air.GetComponent<SpriteRenderer>().active = false;
			if (!this.apeared) this.makeApearAnimation();
			if (GetComponent<SpriteRenderer>().enabled == false) GetComponent<SpriteRenderer>().enabled = true;
			if (GetComponent<Rigidbody2D>().isKinematic == true) GetComponent<Rigidbody2D>().isKinematic = false;
			if (this.scripts.GetComponentInChildren<GameController>().getTraveled() == true && theOne == false) Destroy(this.gameObject);
			this.updateMove();
			this.updateSpells();
		}
		else
		{
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
	
	
	public void makeApearAnimation()
	{
		AudioSource.PlayClipAtPoint(this.appearSound, this.transform.position);
		GameObject appear = (GameObject) Instantiate(this.appearAnimation, this.transform.position, this.transform.rotation);
		Destroy(appear, 0.333f);
		this.apeared = true;
	}


	//The idea is to check if something is colliding with our player
	void OnCollisionStay2D(Collision2D collision) {
		foreach (ContactPoint2D contact in collision.contacts) {
			if(contact.collider.name.Equals("floor")){
				this.grounded = true;
				return;
			}
		}
	}
	
	void updateMove()
	{
		this.moving = false;

		Debug.Log (grounded);

		//Debug.Log("Strange Formula Value: "+ this.rigidbody2D.velocity +"Inertia" +this.rigidbody2D + "Coliding:"+this.gameObject.collider2D);

		this.vSpeed = this.rigidbody2D.velocity.y;


		//TODO: This is a good solution for event every level but 5 (I have to find a solution)
		if (!jumping && (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && (this.grounded || this.rigidbody2D.velocity.y == 0)) {
			this.rigidbody2D.AddForce (Vector2.up * this.jumpForce);
			this.moving = true;
			this.jumping = true;
		} else {
			this.jumping = false;
		}
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (this.transform.localScale.x != 0.5f) this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			if(this.rigidbody2D.velocity.x < 3)
				this.rigidbody2D.AddRelativeForce(Vector2.right * this.speed * 5);
			this.moving = true;
			this.right = true;
		}
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if(this.transform.localScale.x != -0.5f) this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
			if(this.rigidbody2D.velocity.x > -3)
				this.rigidbody2D.AddRelativeForce(-Vector2.right * this.speed * 5);
			this.moving = true;
			this.right = true;
		}
		if (moving) {
			this.anim.SetInteger ("State", 1);
		} else {
			this.anim.SetInteger ("State", 0);
			if(this.rigidbody2D.velocity.y == 0)
				this.rigidbody2D.velocity = Vector2.zero;
		}

		this.grounded = false;
		
	}
	
	void updateSpells()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (this.scripts.GetComponentInChildren<GameController>().UseGem())
			{
				this.theOne = true;
				this.apeared = false;
				this.scripts.GetComponentInChildren<GameController>().changeWorld(this.scripts.GetComponentInChildren<GameController>().getActualWorld());
				this.anim.SetInteger("State", 2);
				
			}
		}
		if ((Input.GetKeyDown(KeyCode.Alpha2) && this.scripts.GetComponentInChildren<GameController>().getAirshocks() > 0) || ( Input.GetKeyDown(KeyCode.Alpha2) && this.scripts.GetComponentInChildren<GameController>().getActualWorld() == 3 ))
		{
			
			AudioSource.PlayClipAtPoint(this.airshockSound, this.transform.position);
			if(this.right) this.rigidbody2D.AddForce(this.transform.right * 250f);
			else this.rigidbody2D.AddForce(-this.transform.right * 250f);
			this.scripts.GetComponentInChildren<GameController>().useAirshock();
			this.anim.SetInteger("State", 2);
			air.GetComponent<SpriteRenderer>().active = true;
			
		}
		
		
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (this.scripts.GetComponentInChildren<GameController>().getFireballs())
			{
				
				
				AudioSource.PlayClipAtPoint(this.fireballSound, this.transform.position);
				Rigidbody2D clone =  (Rigidbody2D) Instantiate(this.fireball,GameObject.Find("cannon").transform.position,this.transform.rotation);
				if (this.right)
				{
					
					clone.transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
					clone.AddForce(Vector3.right * 500);
				}
				
				if (!this.right)
				{
					clone.AddForce(-Vector3.right * 500);
				}
			}   
		}
	}
	
	public void SetPosition(Vector3 newPosition)
	{
		this.transform.position = newPosition;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name.Equals("AirShock") && this.scripts.GetComponentInChildren<GameController>().getActualWorld() == 3)
		{
			AudioSource.PlayClipAtPoint(this.take, this.transform.position);
		}
		
		if (col.collider.name.Equals("AirShock") && this.scripts.GetComponentInChildren<GameController>().getActualWorld() != 3)
		{
			AudioSource.PlayClipAtPoint(this.tink, this.transform.position);
		}
		else if (col.collider.name.Equals("Fireball"))
		{
			AudioSource.PlayClipAtPoint(this.take, this.transform.position);
		}
	}
}
