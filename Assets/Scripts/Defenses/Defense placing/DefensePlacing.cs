using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class DefensePlacing : MonoBehaviour
{
    [System.Serializable]
    public class PlaceableObject
    {
        public GameObject prefab;
        public bool isSelected;
    }

    public List<PlaceableObject> objectsToPlace;

    [Header("AR Raycast")]
    public ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TryPlaceObject(Input.GetTouch(0).position);
        }
    }

    void TryPlaceObject(Vector2 screenPos)
    {
        PlaceableObject selected = GetSelectedObject();
        if (selected == null || selected.prefab == null)
        {
            Debug.LogWarning("Aucun objet sélectionné.");
            return;
        }

        if (raycastManager.Raycast(screenPos, hits, TrackableType.Planes))
        {
            Pose hitPose = hits[0].pose;
            Instantiate(selected.prefab, hitPose.position, hitPose.rotation);
            Debug.Log("Objet placé sur une surface AR à : " + hitPose.position);
        }
        else
        {
            Debug.Log("Aucune surface AR détectée.");
        }
    }

    PlaceableObject GetSelectedObject()
    {
        foreach (var obj in objectsToPlace)
        {
            if (obj.isSelected)
                return obj;
        }
        return null;
    }
}