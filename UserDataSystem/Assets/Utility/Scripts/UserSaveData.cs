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
        [SerializeField] private bool  _activeHaptic = false;

        [Space(1.5f)] [Header("Int")]
        [SerializeField] private int   _currStage    = 0;
        [SerializeField] private int   _userLevel    = 0;
        [SerializeField] private int   _userCoin     = 0;

        [Space(1.5f)] [Header("Float")]
        [SerializeField] private float _clearPercent = 0.0f;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        // ----- Boolean
        public bool ActiveHaptic
        {
            get => _activeHaptic;
            set => _activeHaptic = value;
        }

        // ----- Int
        public int CurrStage
        {
            get => _currStage;
            set => _currStage = value;
        }

        public int UserLevel
        {
            get => _userLevel;
            set => _userLevel = value;
        }

        public int UserCoin
        {
            get => _userCoin;
            set => _userCoin = value;
        }

        // ----- Float
        public float ClearPercent
        {
            get => _clearPercent;
            set => _clearPercent = value;
        }
    }
}