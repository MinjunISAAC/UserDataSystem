// ----- C#
using System;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ----- User Defined
using Utility.ForData.User;

namespace Test.UI 
{
    public class TestView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Boolean")]
        [SerializeField] private Button          _BTN_haptic  = null;
        [SerializeField] private Animator        _animBoolean = null;

        [Space(1.5f)] [Header("String")]
        [SerializeField] private TextMeshProUGUI _TMP_dataInfo = null;

        [Space(1.5f)] [Header("Int")]
        [SerializeField] private TextMeshProUGUI _TMP_coin     = null;
        [SerializeField] private Button          _BTN_up       = null;
        [SerializeField] private Button          _BTN_down     = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private const string TRIGGER_ON  = "On";
        private const string TRIGGER_OFF = "Off";

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- ÃÊ±âÈ­
        #region
        // -- Public
        public void OnInIt(Action hapticOnClick, Action coinUpOnClick, Action coinDownOnClick)
        {
            _OnInitBooleanSet(hapticOnClick);              // Boolean Init
            _OnInitStringSet();                            // String Init
            _OnInitIntSet(coinUpOnClick, coinDownOnClick); // Int Init
        }

        public void OnInitBooleanSet()
        {
            var userData_activeHaptic = UserSaveDataManager.UserSaveData.ActiveHaptic;

            if (userData_activeHaptic) _animBoolean.SetTrigger(TRIGGER_ON);
            else                       _animBoolean.SetTrigger(TRIGGER_OFF);
        }

        public void UpdateUserCoinInfo()
        {
            _TMP_coin.text = $"{UserSaveDataManager.UserSaveData.Coin}";
        }

        // -- Private
        private void _OnInitBooleanSet(Action hapticOnClick)
        {
            _BTN_haptic.onClick.AddListener(() => hapticOnClick());
            OnInitBooleanSet();
        }

        private void _OnInitStringSet()
        {
            var userData_lastEnterStr = UserSaveDataManager.UserSaveData.LastEnterStr;

            _TMP_dataInfo.text = userData_lastEnterStr;
        }

        private void _OnInitIntSet(Action coinUpOnClick, Action coinDownOnClick)
        {
            _BTN_up.onClick.AddListener(() => coinUpOnClick());
            _BTN_down.onClick.AddListener(() => coinDownOnClick());

            var userData_coin = UserSaveDataManager.UserSaveData.Coin;

            _TMP_coin.text = $"{userData_coin}";
        }
        #endregion

    }
}