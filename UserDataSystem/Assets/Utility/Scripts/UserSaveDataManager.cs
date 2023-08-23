// ----- C#
using System;
using System.IO;
using System.Text;

// ----- Unity
using UnityEngine;

namespace Utility.ForData.User
{
    public static class UserSaveDataManager
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string FILE_NAME     = "UserSaveData.json";

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static UserSaveData UserSaveData
        { 
            get; 
            private set;
        } = new UserSaveData();

        // ----- Boolean
        public static bool  UserActiveHaptic { get => UserSaveData.ActiveHaptic; }

        // ----- Int
        public static int   UserCurrStage    { get => UserSaveData.CurrStage;    }
        public static int   UserLevel        { get => UserSaveData.UserLevel;    }
        public static int   UserCoin         { get => UserSaveData.UserCoin;     }

        // ----- Float
        public static float UserClearPercent { get => UserSaveData.ClearPercent; }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public static void CreateToUserSaveData(bool ignoreSaveData = false)
        {
            UserSaveData = new UserSaveData();

            //if (!ignoreSaveData)
            //    SaveData();    
        }

        public static void Load()
        {
            if (!_TryLoad(FILE_NAME, out string fileContents))
            {
                Debug.LogError($"[UserSaveDataManager.Load] {FILE_NAME} 파일이 존재하지 않습니다." + $"<color=red>{fileContents}</color>");
                return;
            }

            try
            {
                var pendData= JsonUtility.FromJson<UserSaveData>(fileContents);
                if (pendData == null)
                {
                    Debug.LogError($"[UserSaveDataManager.Load] {FILE_NAME} 파일을 로드하는데 실패했습니다.");
                    return;
                }

                UserSaveData = pendData;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }

            return;
        }
        
        public static void Save()
        {
            var jsonContents = JsonUtility.ToJson(UserSaveData);

            if (!_TrySave(FILE_NAME, jsonContents))
            {
                Debug.LogError($"[UserSaveDataManager.Save] File을 저장하지 못했습니다.");
                return;
            }
        }

        // ----- Private
        private static bool _TryLoad(string fileName, out string fileContents, bool useEncodeFileName = true, bool useEncodeData = true)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileContents = string.Empty;
                return false;
            }

            var filePath = $"{Application.persistentDataPath}/";

            if (useEncodeFileName) filePath += $"{_EncodeingBase64(fileName)}";
            else                   filePath += $"{fileName}";

            if (!File.Exists(filePath)) 
            { 
                fileContents = string.Empty;
                return false;
            } 

            try
            {
                fileContents = File.ReadAllText(filePath);

                if (useEncodeData) fileContents = _DecodeingBase64(fileContents);
                return true;
            }
            catch (Exception e)
            {
                fileContents = $"{e}";
                return false;
            }
        }

        private static bool _TrySave(string fileName, string saveDataContents, bool useEncodeFileName = true, bool useEncodeData = true)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                Debug.LogError("UserSaveDataManager.Save] 파일명이 비어있습니다.");
                return false;
            }

            if (UserSaveData == null)
            {
                Debug.LogError($"[UserSaveDataManager.Save] User Save Data가 생성되지 않았습니다.");
                return false;
            }

            if (string.IsNullOrEmpty(saveDataContents))
            {
                Debug.LogWarning("[UserSaveDataManager.Save] 저장할 컨텐츠가 비어있습니다.");
                return false;
            }

            try
            {
                var fileContents = JsonUtility.ToJson(UserSaveData);

                var filePath = $"{Application.persistentDataPath}/";

                if (useEncodeFileName) filePath += $"{_EncodeingBase64(fileName)}";
                else                   filePath += $"{fileName}";

                try
                {
                    if (useEncodeData) fileContents = _EncodeingBase64(saveDataContents);
                    else fileContents = saveDataContents;

                    File.WriteAllText(filePath, fileContents);

                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError($"<color=red>[UserSaveDataManager._TrySave] {e}</color>");
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.Log($"<color=red>[UserSaveDataManager._TrySave] {e}</color>");
                return false;
            }
        }

        private static string _EncodeingBase64(string textForm)   => Convert.ToBase64String(Encoding.Unicode.GetBytes(textForm));
        private static string _DecodeingBase64(string base64Form) => Encoding.Unicode.GetString(Convert.FromBase64String(base64Form));
    }
}