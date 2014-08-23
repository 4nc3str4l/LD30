using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	// Use this for initialization
    public int id = 0;
    public bool on = false;
    public Sprite on_s, of_s;
    public int afectedID = 1;

	void Start () {
       this.on =  GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().getActive(this.id);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.on) GetComponent<SpriteRenderer>().sprite = on_s;
        else GetComponent<SpriteRenderer>().sprite = of_s;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Equals("Player"))
        {
            this.on = !this.on;
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setActive(id, this.on);
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setActive(afectedID, !this.on);
        }
    }


}
