using UnityEngine;
using System.Collections;

public class aboutScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Escape)){
			Application.LoadLevel("EntryPoint");
		
		}
	}
}
