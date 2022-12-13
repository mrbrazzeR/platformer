using System;
using Newtonsoft.Json;
using UnityEngine;
using Utils;

namespace DataBase
{
    public static class PlayerViewerData
    {
        [JsonProperty("0")] private static PlayerViewData _playerView;

        static PlayerViewerData()
        {
            Load();
        }

        public static void SynchronizeData(string data)
        {
            PlayerPrefs.SetString(DataKeyUtils.PLAYERVIEW_DATA, data);
            _playerView = JsonConvert.DeserializeObject<PlayerViewData>(data);
        }

        public static string GetDataJson()
        {
            return JsonConvert.SerializeObject(_playerView);
        }

        private static void Save()
        {
            PlayerPrefs.SetString(DataKeyUtils.PLAYERVIEW_DATA, JsonConvert.SerializeObject(_playerView));
        }

        private static void Load()
        {
            _playerView =
                JsonConvert.DeserializeObject<PlayerViewData>(PlayerPrefs.GetString(DataKeyUtils.PLAYERVIEW_DATA)) ??
                new PlayerViewData()
                {
                    bodyData = 0, glovesData = 0, headData = 0, weaponData = 0
                };
        }

        public static PlayerViewData GetAllView()
        {
            return _playerView;
        }

        public static void SetData(PlayerViewData data)
        {
            _playerView = data;
            Save();
        }

        public static int GetHead()
        {
            return _playerView.headData;
        }

        public static void SetHead(int data)
        {
            _playerView.headData = data;
            Save();
        }

        public static int GetBody()
        {
            return _playerView.bodyData;
        }

        public static void SetBody(int data)
        {
            _playerView.bodyData = data;
            Save();
        }

        public static int GetWeaponData()
        {
            return _playerView.weaponData;
        }

        public static void SetWeapon(int data)
        {
            _playerView.weaponData = data;
            Save();
        }

        public static int GetGlovesData()
        {
            return _playerView.glovesData;
        }

        public static void SetGloves(int data)
        {
            _playerView.glovesData = data;
            Save();
        }
    }

    [Serializable]
    public class PlayerViewData
    {
        [JsonProperty("0")] public int headData;
        [JsonProperty("1")] public int bodyData;
        [JsonProperty("2")] public int weaponData;
        [JsonProperty("3")] public int glovesData;
    }
}