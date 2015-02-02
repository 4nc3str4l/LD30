using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	// Use this for initialization

    public float shotRate = 1.0f;
    public float nextShot = 0f;

    public AudioClip shot;

    public Rigidbody2D projectil;

    public bool left = true;

	void Start () {

    }
	
	
	// Update is called once per frame
	void Update () {
        if (Time.time > this.nextShot)
        {
            Rigidbody2D clone = (Rigidbody2D)Instantiate(this.projectil, this.gameObject.transform.Find("cannon2").transform.position, this.transform.rotation);
            if(this.left)clone.AddForce((GameObject.Find("Player").gameObject.transform.position - this.transform.position) * Random.Range(10,25));
            else clone.AddForce(Vector3.right * Random.Range(100,250));
            this.nextShot = Time.time + shotRate;
            AudioSource.PlayClipAtPoint(this.shot, this.transform.position);
        }
	}


}
