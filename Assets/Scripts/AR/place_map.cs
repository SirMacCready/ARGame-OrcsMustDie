using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager),
    typeof(ARPlaneManager))]
public class place_map : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Boolean mapPlaced = false;
    
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (mapPlaced) return;
        if (finger.index != 0) return;
        
        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {   
                Pose pose = hit.pose;
                pose.position.y += 0.2f;
                
                Quaternion rotationOffset = Quaternion.Euler(-90f, 0f, 0f);
                Quaternion finalRotation = pose.rotation * rotationOffset;
                
                GameObject map = Instantiate(prefab, pose.position, finalRotation);
                map.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                mapPlaced = true;
                break;
            }
        }
    }
}