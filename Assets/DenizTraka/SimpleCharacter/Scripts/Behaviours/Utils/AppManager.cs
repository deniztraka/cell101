using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class AppManager : MonoBehaviour
    {
        private BaseMobileBehaviour selectedMobile;
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public BaseMobileBehaviour GetSelectedCharacter()
        {
            return selectedMobile;
        }

        public void SetSelectedCharacter(BaseMobileBehaviour mobile)
        {
            selectedMobile = mobile;
        }
    }
}
