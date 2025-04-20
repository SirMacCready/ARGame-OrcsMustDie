using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuBoard : MonoBehaviour
{
    private InputAction touchAction;
    private InputAction mouseAction;

    private void OnEnable()
    {
        // Définir les actions d'entrée pour le toucher et la souris
        touchAction = new InputAction("Touch", binding: "<Touchscreen>/primaryTouch/press", interactions: "press");

        // S'abonner aux événements d'entrée
        touchAction.performed += _ => LoadNextScene();

        // Activer les actions
        touchAction.Enable();
    }

    private void OnDisable()
    {
        // Désactiver les actions lorsque le script est désactivé
        touchAction.Disable();
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }   
}