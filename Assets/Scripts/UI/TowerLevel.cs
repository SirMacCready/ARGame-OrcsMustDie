using UnityEngine;
using TMPro;

public class TowerLevel : MonoBehaviour
{
    public int level = 1;
    public TextMeshPro levelText;

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (levelText != null)
            levelText.text = "Niveau " + level;
    }

    public void Upgrade()
    {
        level++;
        UpdateText();
    }
}
