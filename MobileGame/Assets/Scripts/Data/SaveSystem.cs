using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Controllers.BehaviorControllers;
using Models.Attributes;
using Models.Items;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Data
{
    public static class SaveSystem
    {
        static string playerFile = "Player.tcd";

        public static void SavePlayer(GameObject player)
        {
            string path = Application.persistentDataPath + playerFile;

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            //PlayerData data = new PlayerData(player);
            List<Item> data = new List<Item>();
            for(int i = 0; i < 5; i++)
            {
                data.Add(new Item { Name = "Item", Cost = i, Id = i });
            }

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static void LoadPlayer(GameObject player)
        {
            string path = Application.persistentDataPath + playerFile;
            if(File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                //PlayerData data = formatter.Deserialize(stream) as PlayerData;
                //var playerData = player.GetComponent<EntityAttributes>();


                //playerData.battleAttributes = data.battleAttributes;

                //Vector2 newPos = new Vector2(data.pos_x, data.pos_y);
                //player.transform.position = newPos;

                List<Item> items = (List<Item>)formatter.Deserialize(stream);

                stream.Close();

            } else
            {
                Debug.LogError("Save file not fount in " + path);
            }
        }
    }
}
