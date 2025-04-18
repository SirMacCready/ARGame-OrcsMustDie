using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager _trackedImageManager;
    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged +=
            OnTrackedImagesChanged;
    }
    void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -=
            OnTrackedImagesChanged;
    }
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs
        eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
// Instancier un objet ou activer un prefab associé
        }
    }
}