using UnityEngine;
using System.Collections;

public class Airshock : MonoBehaviour {

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
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setAirshock(2);
            Destroy(this.gameObject);
        }
    }
}
