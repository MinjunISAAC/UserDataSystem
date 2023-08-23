// ----- C#
using System;
using System.Globalization;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForData.User;
using Test.UI;

namespace Main
{
    public class TestMain : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private TestView _textView = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private const int UP_COINVALUE = 10;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        void Start()
        {
            // Save Data Create
            UserSaveDataManager.CreateToUserSaveData(true);

            // Save Data Load
            UserSaveDataManager.Load();

            // Test View Init
            _textView.OnInIt(_OnClickBoolean, _OnClickCoinUp, _OnClickCoinDown);
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Private
        private void _OnClickBoolean()
        {
            if(UserSaveDataManager.UserSaveData.ActiveHaptic) UserSaveDataManager.UserSaveData.ActiveHaptic = false;
            else                                              UserSaveDataManager.UserSaveData.ActiveHaptic = true;

            UserSaveDataManager.Save();
            
            _textView.OnInitBooleanSet();
        }

        private void _OnClickCoinUp()
        {
            UserSaveDataManager.UserSaveData.Coin += UP_COINVALUE;

            UserSaveDataManager.Save();

            _textView.UpdateUserCoinInfo();
        }

        private void _OnClickCoinDown()
        {
            UserSaveDataManager.UserSaveData.Coin -= UP_COINVALUE;

            UserSaveDataManager.Save();

            _textView.UpdateUserCoinInfo();
        }
        private void OnApplicationQuit()
        {
            DateTime    currentDateTime     = DateTime.Now;
            
            var date = currentDateTime.ToString("yyyy-MM-dd tt hh:mm:ss", CultureInfo.GetCultureInfo("ko-KR"));

            if (currentDateTime.Hour >= 12) date = date.Replace("오후", "PM");
            else                            date = date.Replace("오전", "AM");

            UserSaveDataManager.UserSaveData.LastEnterStr = date;
            UserSaveDataManager.Save();
        }
    }
}