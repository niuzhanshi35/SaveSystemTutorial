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

            Debug.Log("�ɹ��洢���ݵ�PlayerPrefs");
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
                Debug.Log($"�ɹ��洢���ݵ� {path}��");
            }
            catch (Exception ex)
            {
                Debug.LogError($"�洢����ʧ��: {ex.Message}");
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
                Debug.LogError($"��������ʧ��: {ex.Message}");

                return default;
            }
        }

        #endregion

        #region ɾ���浵
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            try
            {
            File.Delete(path);

            }
            catch (System.Exception ex)
            {

                Debug.LogError($"ɾ���浵ʧ��: {ex.Message}");
            }
        }


        #endregion
    }
}
