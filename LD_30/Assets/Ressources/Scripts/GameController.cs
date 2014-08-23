using UnityEngine;
using System.Collections.Generic;
using Assets.Ressources.Scripts;

//Conected Worlds....




public class GameController : MonoBehaviour {

    List<Level> levels;

    public bool playerInstanciated;

    public Texture2D powerGemTexture, heartTexture , airshockTexture;
    
    int actualWorld;

    int playerLives;

    bool traveled;

    int playerGems = 8;

    int airshocks;

    bool fireballs;

    float nextTrack = 0;

    public AudioClip m1, m2, m3, m4, m5, m6, m7, m8, m9;
    AudioClip[] music;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        this.actualWorld = 0;
        this.playerInstanciated = true;
        this.traveled = false;

        this.levels = new List<Level>();

        this.playerLives = 5;

        this.airshocks = 0;

        this.fireballs = false;

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
            case 1:
                if (Application.loadedLevelName.Equals("Level2_1")) Application.LoadLevel("Level2_2");
                else Application.LoadLevel("Level2_1");
                break;
            case 2:
                if (Application.loadedLevelName.Equals("Level3_1")) Application.LoadLevel("Level3_2");
                else Application.LoadLevel("Level3_1");
                break;
            case 3:
                if (Application.loadedLevelName.Equals("Level4_1")) Application.LoadLevel("Level4_2");
                else Application.LoadLevel("Level4_1");
                break;
            case 4:
                if (Application.loadedLevelName.Equals("Level5_1")) Application.LoadLevel("Level5_2");
                else Application.LoadLevel("Level5_1");
                break;
            case 5:
                if (Application.loadedLevelName.Equals("Level6_1")) Application.LoadLevel("Level6_2");
                else Application.LoadLevel("Level6_1");
                break;

            case 6:
                if (Application.loadedLevelName.Equals("Level7_1")) Application.LoadLevel("Level7_2");
                else Application.LoadLevel("Level7_1");
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

    public void setActualWorld(int w)
    {
        this.actualWorld = w;
    }

    public bool UseGem()
    {
        if (this.playerGems > 0)
        {
            this.playerGems--;
            return true;
        }
        else
        {
            this.gameOver();
        }
        return false;
    }

   public  void useAirshock()
    {
        if(this.airshocks> 0) this.airshocks--;
    }

    public void setGems(int gems)
    {
        this.playerGems = 8;
    }

    public void addGem()
    {
        if(this.playerGems < 8) this.playerGems++;
    }

    public void setAirshock(int ashocks)
    {
        this.airshocks = ashocks;
    }

    public int getAirshocks()
    {
        return this.airshocks; 
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

            xOffSet = 0;
            for (int i = 0; i < this.playerLives; i++)
            {
                GUI.DrawTexture(new Rect(200f + xOffSet, 18f, 45f, 40f), this.heartTexture);
                xOffSet += 43;
            }

            for (int i = 0; i < this.airshocks; i++)
            {
                GUI.DrawTexture(new Rect(200f + xOffSet, 18f, 45f, 40f), this.airshockTexture);
                xOffSet += 43;
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
        levels.Add(new Level(list, "Level 2", new Vector3(-7.259693f, -4.44933f, 0f)));
        levels.Add(new Level(list, "Level 3", new Vector3(-7.259693f, -4.44933f, 0f)));
        levels.Add(new Level(list, "Level 4", new Vector3(-7.259693f, -4.44933f, 0f)));
        levels.Add(new Level(list, "Level 5", new Vector3(-7.259693f, -4.44933f, 0f)));
        levels.Add(new Level(list, "Level 6", new Vector3(-7.259693f, -4.44933f, 0f)));
        levels.Add(new Level(list, "Level 7", new Vector3(-7.259693f, -4.44933f, 0f)));
    }

    public  Vector3 getSpawnPosition()
    {
        return this.levels[this.actualWorld].getPlayerSpawn();
    }

    public int getPlayerLives()
    {
        return this.playerLives;
    }

    public void hurt()
    {
        GameObject.Find("Player").GetComponentInChildren<Player>().playHurt = true;
        if (this.getActualWorld() > 2) this.airshocks = 2;
        //this.playerLives--;
        this.addGem();
        Vector3 pos = Vector3.zero;

        if (this.actualWorld == 1)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level2_1");
            else
            {
                gameOver();

            }
        }

        if (this.actualWorld == 2)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level3_1");
            else
            {
                gameOver();
            }
        }

        if (this.actualWorld == 3)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level4_1");
            else
            {
                gameOver();
            }
        }

        if (this.actualWorld == 4)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level5_1");
            else
            {
                gameOver();
            }
        }

        if (this.actualWorld == 5)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level6_1");
            else
            {
                gameOver();
            }
        }

        if (this.actualWorld == 6)
        {
            pos = new Vector3(-6.7f, 2.0554f, 0);
            GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(pos);
            if (playerLives > 0) Application.LoadLevel("Level7_1");
            else
            {
                gameOver();
            }
        }


    }

    public void gameOver()
    {
        GameObject.Find("Player").GetComponentInChildren<Player>().playHurt = false;
        GameObject.Find("Player").GetComponentInChildren<Player>().playDead = true;
        this.airshocks = 0;
        this.playerLives = 5;
        this.fireballs = false;
        this.playerGems = 8;
        this.actualWorld = 0;
        GameObject.Find("Player").GetComponentInChildren<Player>().SetPosition(new Vector3(-7.259693f,-4.36438f,0f));
        Application.LoadLevel("Level1_1");
    }

    public void activateFireball()
    {
        this.fireballs = true;
    }

    public bool getFireballs()
    {
        return this.fireballs;
    }

}
