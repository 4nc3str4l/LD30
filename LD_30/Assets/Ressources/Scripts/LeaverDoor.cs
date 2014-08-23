using UnityEngine;
using System.Collections;

public class LeaverDoor : MonoBehaviour {

	// Use this for initialization
    public int id = 1;
    public bool on = true;
	void Start () {
        this.on = GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().getActive(this.id);
        GetComponent<BoxCollider2D>().isTrigger = !this.on;
        GetComponent<SpriteRenderer>().active = this.on;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
