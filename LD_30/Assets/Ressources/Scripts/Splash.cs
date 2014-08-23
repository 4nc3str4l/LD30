using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Return))
        {
            Application.LoadLevel("Level1_1");
        }
	}
}
