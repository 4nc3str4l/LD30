using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	public Texture normal, selectedtexture;
	public AudioClip tick;
	
	public bool selected;

	void Start() {
		this.selected = false;
	}

	void Update(){
		if (this.selected)
		{
			GetComponent<GUITexture>().texture = selectedtexture;
		}
		else
		{
			GetComponent<GUITexture>().texture = normal;
		}
		
		this.selected = false;
	}

    void OnMouseOver()
    {
		this.selected = true;
	
        if (Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel("splash");
        }
    }

	void OnMouseEnter(){
		AudioSource.PlayClipAtPoint(this.tick,this.transform.position);	
	}

}
