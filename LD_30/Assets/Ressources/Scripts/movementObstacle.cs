using UnityEngine;
using System.Collections;

public class movementObstacle : MonoBehaviour {

	// Use this for initialization

    public bool move = false;
    public bool rotates = false;
    public bool left = true;

    public int movementRange = 3;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.rotates && this.left) this.transform.Rotate(0, 0f, 20f * Time.deltaTime, Space.World);
        if (this.rotates && !this.left) this.transform.Rotate(0, 0f, -20f * Time.deltaTime, Space.World);   
	}
}
