using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("Fire1"))
        {
            Application.LoadLevel("Splash");
        }

        if (GameObject.Find("_SCRIPTS") != null && GameObject.Find("Player") != null)
        {
            Destroy(GameObject.Find("_SCRIPTS").gameObject);
            Destroy(GameObject.Find("Player").gameObject);

        }
	}
}
