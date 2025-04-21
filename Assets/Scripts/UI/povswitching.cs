using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class povswitching : MonoBehaviour
    {
        private Camera _cam1 ;
        private Camera _cam2 ;
        private GameObject[] tabletop ;
        private GameObject[] FPS;
        public Button povSwitch;
  
        void Start() {
            _cam1.enabled = true;
            _cam2.enabled = false;
            if (povSwitch != null)
            {
                povSwitch.onClick.AddListener(PovSwitch);
                print("pov listener added");
            }
            else
            {
                print("pov is not assigned");
            }
        }
  
        void PovSwitch() {
            _cam1 = GameObject.FindGameObjectWithTag("Tabletop Camera").GetComponent<Camera>();
            _cam2 = GameObject.FindGameObjectWithTag("FPS Camera").GetComponent<Camera>();
            tabletop = GameObject.FindGameObjectsWithTag("Tabletop");
            FPS =  GameObject.FindGameObjectsWithTag("FPS");
            
            if (_cam1.enabled) {
                _cam1.enabled = false;
                _cam2.enabled = true;
                foreach (GameObject tabletop in tabletop)
                {
                    tabletop.SetActive(false);
                }

                foreach (GameObject tabletop in FPS)
                {
                    tabletop.SetActive(true);
                }

            }
            else
            {
                _cam1.enabled = true;
                _cam2.enabled = false;

                foreach (GameObject tabletop in tabletop)
                {
                    tabletop.SetActive(true);
                }

                foreach (GameObject tabletop in FPS)
                {
                    tabletop.SetActive(false);
                }
            }
        }

    }
}