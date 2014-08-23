using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Ressources.Scripts
{
    class Level
    {
        string name;
        List<bool> list;
        Vector3 playerSpawn;

        public Level(List<bool> array, string name,Vector3 playerSpawn)
        {
            this.name = name;
            this.list = array;
            this.playerSpawn = playerSpawn;
        }

        public void setObject(int id,bool enabled){
            this.list[id] = enabled;
        }

        public bool getObjectState(int id)
        {
            return this.list[id];
        }

        public Vector3 getPlayerSpawn()
        {
            return this.playerSpawn;
        }
    }
}
