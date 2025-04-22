using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PovSwitcher : MonoBehaviour
    {
        [Header("Tabletop Origin")] 
        [SerializeField] private GameObject tabletopOrigin;
        [Header("FPS Origin")] 
        [SerializeField] private GameObject FPSOrigin;

        [Header("UI Elements")]
        [SerializeField] private Button povSwitchButton;

        private void Start()
        {
            if (povSwitchButton != null)
            {
                povSwitchButton.onClick.AddListener(switchPov);
                print("PovSwitchButton is On");
            }
            else
            {
                print("PovSwitchButton is null");
            }
        }

        public void switchPov()
        {
            print("switching pov");
            if (tabletopOrigin.activeInHierarchy)
            {
                tabletopOrigin.SetActive(false);
                FPSOrigin.SetActive(true);
                print("FPS ON");
            }
            else
            {
                tabletopOrigin.SetActive(true);
                FPSOrigin.SetActive(false);
                print("Tabletop ON");
            }
        }
    }
}
