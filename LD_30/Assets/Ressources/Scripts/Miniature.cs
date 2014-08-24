using UnityEngine;
using System.Collections;

public class Miniature : MonoBehaviour {


	public AudioClip tick;

    public int level = 1;

    public Texture normal, selectedtexture;

    public bool selected;

	// Use this for initialization
	void Start () {
        this.selected = false;
	}
	
	// Update is called once per frame
	void Update () {

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
        GameObject.Find("Levels").GetComponentInChildren<Levels>().setSelectedLevel(level);
    }

	void OnMouseEnter(){
		AudioSource.PlayClipAtPoint(this.tick,this.transform.position);	
	}

}
