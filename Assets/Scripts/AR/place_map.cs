using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Lumin;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlaceMap : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject map;
    public Camera arCamera;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool mapPlaced = false; // Track if the map has been placed
    public GameObject startHUD;
    public GameObject tabletopHUD;

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        if (mapPlaced)
        {
            return; // Exit if the map has already been placed
        }

        if (Touch.activeTouches.Count > 0)
        {
            Touch touch = Touch.activeTouches[0];
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                // Cast a ray from the camera's position in the direction it is facing
                Ray ray = new Ray(arCamera.transform.position, arCamera.transform.forward);

                if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    hitPose.rotation.y += 180f;
                    Vector3 adjustedPosition = hitPose.position;
                    GameObject placedMap = Instantiate(map, adjustedPosition, hitPose.rotation);

                    // Scale the map to one-tenth of its true scale
                    placedMap.transform.localScale = map.transform.localScale * 0.05f;

                    // Set the map as placed
                    mapPlaced = true;
                    planeManager.enabled = false;
                    startHUD.SetActive(false);
                    tabletopHUD.SetActive(true);
                    
                    
                }
            }
        }
    }
}