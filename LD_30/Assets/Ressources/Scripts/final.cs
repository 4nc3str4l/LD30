using UnityEngine;
using System.Collections;

public class final : MonoBehaviour {


	public AudioClip tick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Player")!=null){
            Destroy(GameObject.Find("Player").gameObject);
            Destroy(GameObject.Find("_SCRIPTS").gameObject);
		}

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("Fire1"))
        {
            Application.LoadLevel("EntryPoint");
        }

	}
}
