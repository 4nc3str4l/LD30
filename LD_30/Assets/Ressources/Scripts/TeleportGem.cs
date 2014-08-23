using UnityEngine;
using System.Collections;

public class TeleportGem : MonoBehaviour {

	// Use this for initialization

    public AudioClip tick;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Equals("Player"))
        {
            AudioSource.PlayClipAtPoint(this.tick,this.transform.position);
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().addGem();
            Destroy(this.gameObject);
        }
    }
}
