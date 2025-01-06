using UnityEditor;
using UnityEngine;
namespace SaveSystemTutorial
{    
    public class PlayerData : MonoBehaviour
    {
        private const string PLAYER_DATA_KEY = "PlayerData";
        const string PLAYER_DATA_FILE_NAME = "PlayerData.json";
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
            //SaveByPlayerPrefs();
            SaveByJson();
        }

        public void Load()
        {
            //LoadFromPlayerPrefs();
            LoadFromJson();
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
            SaveData savaData = SavingData();

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
            var saveData = JsonUtility.FromJson<SaveData>(json);
            LoadData(saveData);
        }


        private void Update()
        {
            // 检测是否按下了 P 键
            if (Input.GetKeyDown(KeyCode.P))
            {
                // 调用自定义函数
                //  DeletePlayerDataPrefs();
                DeleteSaveFile();
            }
        }
        public static void DeletePlayerDataPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
        #endregion
        void SaveByJson()
        {
            // SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
            SaveSystem.SaveByJson($"{System.DateTime.Now:yyyy.M.dd.HH-mm-ss}.sav", SavingData());
        }
        void LoadFromJson()
        {
           var  saveData=SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
            LoadData(saveData);
        }
        SaveData SavingData()
        {
            var savaData = new SaveData();

            savaData.playerName = playerName;
            savaData.playerLevel = level;
            savaData.playerCoin = coin;
            savaData.playerPosition = transform.position;
            return savaData;
        }

        private void LoadData(SaveData saveData)
        {
            playerName = saveData.playerName;
            level = saveData.playerLevel;
            coin = saveData.playerCoin;
            transform.position = saveData.playerPosition;
        }
        public static void DeleteSaveFile()
        {
            SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
        }
    }
}