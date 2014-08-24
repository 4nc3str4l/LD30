using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

    int level;
    int numLevels;

    public GUITexture l1, l2, l3, l4, l5, l6, l7, l8;
    public GUITexture sl1, sl2, sl3, sl4, sl5, sl6, sl7, sl8;

	// Use this for initialization
	void Start () {
        this.level = 0;
        this.numLevels = 8;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            this.level--;
            if (this.level < 0)
            {
                this.level = numLevels - 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            this.level++;
            if (this.level > (numLevels-1))
            {
                this.level = 0;
            }

        }

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("Fire1"))
        {
            selectLevel(level);
        }
	}


    void updateLevel(){

    }

    public void setSelectedLevel(int lvl)
    {
        level = lvl;
    }


    void selectLevel(int id)
    {
        GameObject.Find("Player").transform.position = new Vector3(-6.7f, 2.0554f, 0);
        GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setActualWorld(id);
        if (id > 3)
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setAirshock(2);
        else
        {
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().setAirshock(0);
        }
        if (id > 7)
        {

            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().activateFireball();

            Debug.Log("FireballStatus" + GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().getFireballs().ToString());
        }
        else
        {
            GameObject.Find("_SCRIPTS").GetComponentInChildren<GameController>().desactivateFirebal();
        }
        switch (id)
        {
            case 0:
			    Application.LoadLevel("Level1_1");
                break;
            case 1:
                Application.LoadLevel("Level2_1");
                break;
            case 2:
                Application.LoadLevel("Level3_1");
                break;
            case 3:
                Application.LoadLevel("Level4_1");
                break;
            case 4:
                Application.LoadLevel("Level5_1");
                break;

            case 5:
                Application.LoadLevel("Level6_1");
                break;
            case 6:
                Application.LoadLevel("Level7_1");
                break;
            case 7:
                Application.LoadLevel("Level8_1");
                break;
            case 8:
                Application.LoadLevel("Level9_1");
                break;
            case 9:
                Application.LoadLevel("Level10_1");
                break;
            case 10:
                Application.LoadLevel("Level11_1");
                break;
            case 11:
                Application.LoadLevel("Level12_1");
                break;
            default:
                break;
        }
    }
}
