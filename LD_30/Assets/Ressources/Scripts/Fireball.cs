using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public AudioClip explosionSound;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Equals("Player"))
        {
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().activateFireball();
            Destroy(this.gameObject);
        }
        else if (col.collider.name.Equals("turret") || col.collider.name.Equals("Projectil(Clone)"))
        {
            AudioSource.PlayClipAtPoint(this.explosionSound, this.transform.position);
            GameObject explosion = (GameObject)Instantiate(this.explosion, this.transform.position, this.transform.rotation);
            Destroy(explosion, 1.117f);
            Destroy(col.gameObject);
            Destroy(this.gameObject);



        }
        else
        {
            GameObject explosion = (GameObject)Instantiate(this.explosion, this.transform.position, this.transform.rotation);
            Destroy(explosion, 0.5585f);
            AudioSource.PlayClipAtPoint(this.explosionSound, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
