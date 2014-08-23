using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	// Use this for initialization

    public string goalName;
    public int destination;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Equals("Player"))
        {
            col.transform.position = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setActualWorld(destination);
			if(GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().getActualWorld() > 3) 
				GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setAirshock(2);

			Application.LoadLevel(goalName);
        }

    }
    
}
