using UnityEngine;
using System.Collections;

public class mageStaff : MonoBehaviour {

	public AudioClip clip;

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
			AudioSource.PlayClipAtPoint(this.clip,this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
