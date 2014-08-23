using UnityEngine;
using System.Collections;

//Conected Worlds....




public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void changeWorld(int destWorld)
    {
        switch (destWorld)
        {
            case 1:
                if (Application.loadedLevelName.Equals("Level1_1")) Application.LoadLevel("Level1_2");
                else Application.LoadLevel("Level1_1");
                break;
        }
    }
}
