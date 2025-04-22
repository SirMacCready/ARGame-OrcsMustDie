using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class toggle : MonoBehaviour
{
    [System.Serializable]
    public class ToggleBinding
    {
        public Toggle toggle;
        public DefensePlacing.PlaceableObject targetObject;
    }

    public List<ToggleBinding> toggleBindings;

    void Start()
    {
        foreach (var binding in toggleBindings)
        {
            // Important : capture locale
            Toggle localToggle = binding.toggle;
            DefensePlacing.PlaceableObject localTarget = binding.targetObject;

            localToggle.onValueChanged.AddListener((bool isOn) =>
            {
                if (isOn)
                {
                    DeselectAll();
                    localTarget.isSelected = true;
                    localToggle.isOn = true; // Réactive le toggle actif
                }
            });
        }
    }

    void DeselectAll()
    {
        foreach (var binding in toggleBindings)
        {
            binding.targetObject.isSelected = false;
            binding.toggle.isOn = false;
        }
    }
}