using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveSystemTutorial
{
    public static class SaveSystem 
    {
        #region     PlayerPrefs
        public static void SaveByPlayerPrefs(string key,object data)
        {
            var json=JsonUtility.ToJson(data);
            Debug.Log(json);

            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();

            Debug.Log("成功存储数据到PlayerPrefs");
        }

        public static string LoadFromPlayerPrefs(string key)
        {
            return PlayerPrefs.GetString(key,null);
        }
        #endregion

        #region JSON

        public static void SaveByJson(string saveFileName,object data)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, saveFileName);

            try
            {
                File.WriteAllText(path, json);
                Debug.Log($"成功存储数据到 {path}。");
            }
            catch (Exception ex)
            {
                Debug.LogError($"存储数据失败: {ex.Message}");
            }


        }

        public static  T LoadFromJson<T>(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);

          
            try
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<T>(json);
                return data;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"加载数据失败: {ex.Message}");

                return default;
            }
        }

        #endregion

        #region 删除存档
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            try
            {
            File.Delete(path);

            }
            catch (System.Exception ex)
            {

                Debug.LogError($"删除存档失败: {ex.Message}");
            }
        }


        #endregion
    }
}
