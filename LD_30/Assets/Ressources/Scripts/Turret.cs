using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	// Use this for initialization

    public float shotRate = 1.0f;
    public float nextShot = 0f;

    public AudioClip shot;

    public Rigidbody2D projectil;

	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > this.nextShot)
        {
            Rigidbody2D clone = (Rigidbody2D)Instantiate(this.projectil, GameObject.Find("cannon2").transform.position, this.transform.rotation);
            clone.AddForce(-Vector3.right * 100);
            this.nextShot = Time.time + shotRate;
            AudioSource.PlayClipAtPoint(this.shot, this.transform.position);
        }
	}


}
