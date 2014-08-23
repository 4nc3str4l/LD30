using UnityEngine;
using System.Collections;

public class Filter : MonoBehaviour {

	// Use this for initialization



	void Start () {
	
		RenderSettings.ambientLight = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	Texture2D createNewTexture(Color col, int w , int h){
		Color[] pixels = new Color[w * h];

		for(int i = 0;i<pixels.Length;i++){
			pixels[i] = col;
		}

		Texture2D text = new Texture2D(w,h);

		text.SetPixels(pixels);

		return text;


	}

	void OnGUI(){

	}
}
