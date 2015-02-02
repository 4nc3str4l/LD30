using UnityEngine;
using System.Collections;

public class Filter : MonoBehaviour {

	// Use this for initialization

	public float shotRate = 0.1f;
	public float nextShot;
	void Start () {
		this.nextShot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("updating");
		if (Time.time > this.nextShot) {
			RenderSettings.ambientLight = new Color (0f, 0f ,Random.Range (0.1f,1f) , 1f);
			this.nextShot = Time.time + shotRate;
			Debug.Log("changing color");
		}
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

	public static Texture2D createNewTexture(int w , int h){
		Color[] pixels = new Color[w * h];  
		
		for(int i = 0;i<pixels.Length;i++){
			pixels[i] = new Color (0f, 0f ,Random.Range (0.1f,1f) , 0.1f);
		}
		
		Texture2D text = new Texture2D(w,h);
		
		text.SetPixels(pixels);
		
		return text;
		
		
	}

	void OnGUI(){

	}
}
