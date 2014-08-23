using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization

    public float speed = 3f;
    public float jumpForce = 3f;

    private bool moving  = false;

    private float jumpRate, nextJump;

    Animator anim;
	void Start () {
        this.anim = this.GetComponentInChildren<Animator>();
        this.jumpRate = 1f;
        this.nextJump = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        this.updateMove();
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
}
