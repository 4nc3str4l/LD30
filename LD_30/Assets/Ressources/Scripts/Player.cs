using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization

    public float speed = 3f;
    public float jumpForce = 3f;

    private bool moving  = false;

    private float jumpRate, nextJump;

    public GameObject scripts,appearAnimation;

    public AudioClip appearSound, airshockSound, hurt,dead, fireballSound;

    public bool theOne;

    public bool apeared;

    private bool right;

    GameObject air;

    public bool playHurt, playDead;

    float nextShot, shotRate;

    public Rigidbody2D fireball;



    Animator anim;
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

        this.shotRate = 1.5f;
        this.nextShot = 0f;



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

            Debug.Log(this.scripts.GetComponentInChildren<GameController>().getTraveled().ToString());
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

    void updateMove()
    {
        this.moving = false;
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > this.nextJump)
        {
            this.nextJump = Time.time + this.jumpRate;
            this.rigidbody2D.AddForce(Vector2.up * this.jumpForce);
            this.moving = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.localScale.x != 0.5f) this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
            this.moving = true;
            this.right = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.transform.localScale.x != -0.5f) this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            this.transform.Translate(-Vector3.right * this.speed * Time.deltaTime);
            this.moving = true;
            this.right = false;
        }
        if (moving) this.anim.SetInteger("State", 1);
        else this.anim.SetInteger("State", 0);

    }

    void updateSpells()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (this.scripts.GetComponentInChildren<GameController>().UseGem())
            {
                 /*
				if(this.scripts.GetComponentInChildren<GameController>().getActualWorld()==0){
                	Vector3 pos = this.scripts.GetComponentInChildren<GameController>().getSpawnPosition();
                	Debug.Log("new position " + pos.ToString());
                	this.transform.position = pos;
				}*/
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
                     clone.AddForce(Vector3.right * 200);
                 }

                 if (!this.right)
                 {
                     clone.AddForce(-Vector3.right * 400);
                 }
            }   
        }
    }



    public void SetPosition(Vector3 newPosition)
    {
        this.transform.position = newPosition;
    }
}
