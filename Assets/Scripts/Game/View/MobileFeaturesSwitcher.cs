using UnityEngine;

namespace Scripts.Game.View
{
    public class MobileFeaturesSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] _mobileFeatures;


        public void Awake()
        {
            foreach(var mobileFeature in _mobileFeatures)
                mobileFeature.SetActive(Application.isMobilePlatform);
        }
    }
}