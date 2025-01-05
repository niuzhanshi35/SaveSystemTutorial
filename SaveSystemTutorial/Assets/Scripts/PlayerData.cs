using UnityEditor;
using UnityEngine;
namespace SaveSystemTutorial
{    
    public class PlayerData : MonoBehaviour
    {
        private const string PLAYER_DATA_KEY = "PlayerData";
        #region Fields

        [SerializeField] string playerName = "Player Name";
        [SerializeField] int level = 0;
        [SerializeField] int coin = 0;

        #endregion

        [System.Serializable] class SaveData
        {
            public string playerName;
            public int playerLevel;
            public int playerCoin;
            public Vector3 playerPosition;
        }

        #region Properties

        public string Name => playerName;

        public int Level => level;
        public int Coin => coin;

        public Vector3 Position => transform.position;

        #endregion

        #region Save and Load

        public void Save()
        {
            SaveByPlayerPrefs();
        }

        public void Load()
        {
            LoadFromPlayerPrefs();
        }
        void SaveByPlayerPrefs()
        {
            /*
            PlayerPrefs.SetString("PlayerName", playerName);

            PlayerPrefs.SetInt("PlayerLevel",level);
            PlayerPrefs.SetInt("PlayerCoin",coin);

            PlayerPrefs.SetFloat("PlayerPositionX",transform.position.x);
            PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
            PlayerPrefs.SetFloat("PlayerPositionZ", transform.position.z);

            PlayerPrefs.Save();*/
            var savaData=new SaveData();

            savaData.playerName=playerName;
            savaData.playerLevel=level;
            savaData.playerCoin=coin;
            savaData.playerPosition=transform.position;

            SaveSystem.SaveByPlayerPrefs(PLAYER_DATA_KEY, savaData);
        }
        void LoadFromPlayerPrefs()
        {
            /* playerName=PlayerPrefs.GetString("PlayerName","aabb");

             level = PlayerPrefs.GetInt("PlayerLevel", 0);
             coin = PlayerPrefs.GetInt("PlayerCoin", 0);

             transform.position = new Vector3(

                 PlayerPrefs.GetFloat("PlayerPositionX", 0f),
                 PlayerPrefs.GetFloat("PlayerPositionY", 0f),
                 PlayerPrefs.GetFloat("PlayerPositionZ", 0f)
                 );*/
            var json = SaveSystem.LoadFromPlayerPrefs(PLAYER_DATA_KEY);
            var saveData=JsonUtility.FromJson<SaveData>(json);

            playerName = saveData.playerName;
            level = saveData.playerLevel;
            coin = saveData.playerCoin;
            transform.position = saveData.playerPosition;
        }


        private void Update()
        {
            // 检测是否按下了 P 键
            if (Input.GetKeyDown(KeyCode.P))
            {
                // 调用自定义函数
                DeletePlayerDataPrefs();
            }
        }
        public static void DeletePlayerDataPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
        #endregion
    }
}