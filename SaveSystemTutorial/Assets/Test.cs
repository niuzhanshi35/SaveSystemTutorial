using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystemTutorial
{
    public class Test : MonoBehaviour
    {
        public bool testBool;
        private void Start()
        {
           print( JsonUtility.ToJson(testBool));
        }
    }
}
