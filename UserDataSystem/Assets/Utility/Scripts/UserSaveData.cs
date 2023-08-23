// ----- C#
using System;

// ----- Unity
using UnityEngine;

namespace Utility.ForData.User
{
    [Serializable]
    public class UserSaveData
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Boolean")]
        [SerializeField] private bool   _activeHaptic = false;

        [Space(1.5f)] [Header("String")]
        [SerializeField] private string _lastEnterStr = null; 

        [Space(1.5f)] [Header("Int")]
        [SerializeField] private int    _userCoin     = 0;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        // ----- Boolean
        public bool ActiveHaptic
        {
            get => _activeHaptic;
            set => _activeHaptic = value;
        }

        // ----- String
        public string LastEnterStr
        {
            get => _lastEnterStr;
            set => _lastEnterStr = value;
        }

        // ----- Int
        public int Coin
        {
            get => _userCoin;
            set => _userCoin = value;
        }
    }
}