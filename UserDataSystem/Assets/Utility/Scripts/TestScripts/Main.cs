// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForData.User;

namespace Main
{
    public class Main : MonoBehaviour
    {
        void Start()
        {
            // Save Data ·Îµå
            UserSaveDataManager.Load();
        }
    }
}