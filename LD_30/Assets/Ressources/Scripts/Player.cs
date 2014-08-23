using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization

    public float speed = 3f;
    public float jumpForce = 3f;

    private bool moving  = false;

    private float jumpRate, nextJump;

    public GameObject scripts,appearAnimation;

    public AudioClip appearSound;

    public bool theOne;

    public bool apeared;


    Animator anim;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.anim = this.GetComponentInChildren<Animator>();
        this.jumpRate = 1f;
        this.nextJump = 0f;
        this.theOne = false;
        this.apeared = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!Application.loadedLevelName.Equals("splash"))
        {
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
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.transform.localScale.x != -0.5f) this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            this.transform.Translate(-Vector3.right * this.speed * Time.deltaTime);
            this.moving = true;
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

                Vector3 pos = this.scripts.GetComponentInChildren<GameController>().getSpawnPosition();
                Debug.Log("new position " + pos.ToString());
                this.transform.position = pos;
                this.theOne = true;
                this.apeared = false;
                this.scripts.GetComponentInChildren<GameController>().changeWorld(this.scripts.GetComponentInChildren<GameController>().getActualWorld());
            
            }
        }
    }
}
