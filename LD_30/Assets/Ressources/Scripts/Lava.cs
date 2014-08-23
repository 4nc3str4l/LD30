using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	// Use this for initialization



    float soundRate = 20f;
    float nextSound = 0;

	void Start () {

    
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Equals("Player"))
        {
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().hurt();
        }
    }
}
