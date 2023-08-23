// ----- C#
using System;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInIt()
        {

        }
    }
}