using UnityEngine;
using System.Collections.Generic;
using Assets.Ressources.Scripts;

//Conected Worlds....




public class GameController : MonoBehaviour {

    List<Level> levels;

    public bool playerInstanciated;

    public Texture2D powerGemTexture;
    
    int actualWorld;

    bool traveled;

    int playerGems = 8;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        this.actualWorld = 0;
        this.playerInstanciated = true;
        this.traveled = false;

        this.levels = new List<Level>();

        createLevels();

    }
	
	// Update is called once per frame
	void Update () {
    
	}


    public void changeWorld(int destWorld)
    {
        this.traveled = true;
        switch (destWorld)
        {
            case 0:
                if (Application.loadedLevelName.Equals("Level1_1")) Application.LoadLevel("Level1_2");
                else Application.LoadLevel("Level1_1");
                break;
        }

    }

    public int getActualWorld()
    {
        return this.actualWorld;
    }


    public int getGems()
    {
        return this.playerGems;
    }

    public bool UseGem()
    {
        if (this.playerGems > 0)
        {
            this.playerGems--;
            return true;
        }
        return false;
    }

    public void setGems(int gems)
    {
        this.playerGems = 8;
    }

    public void addGem()
    {
        if(this.playerGems < 8) this.playerGems++;
    }

    public void OnGUI()
    {
        if (!Application.loadedLevelName.Equals("splash"))
        {
            int xOffSet = 0;
            for (int i = 0; i < this.playerGems; i++)
            {
                GUI.DrawTexture(new Rect(545f + xOffSet, 18f, 29f, 40f), this.powerGemTexture);
                xOffSet += 33;
            }
        }
    }

    public bool getTraveled()
    {
        return this.traveled;
    }


    public bool getActive(int id)
    {
        return levels[this.actualWorld].getObjectState(id);
    }

    public void setActive(int id, bool active)
    {
        levels[this.actualWorld].setObject(id, active);
    }

    void createLevels()
    {
        List<bool> list = new List<bool>();
        list.Add(false);
        list.Add(true);

        levels.Add(new Level(list, "Level 1", new Vector3(-7.259693f, -4.44933f, 0f)));
    }

    public  Vector3 getSpawnPosition()
    {
        return this.levels[this.actualWorld].getPlayerSpawn();
    }


}
