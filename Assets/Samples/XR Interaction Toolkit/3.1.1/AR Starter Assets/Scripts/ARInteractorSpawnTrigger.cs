#if AR_FOUNDATION_PRESENT
using UnityEngine;
using UnityEngine.XR.ARFoundation;

using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.ARStarterAssets
{
    /// <summary>
    /// Spawns an object at the hit position of a raycast if it hits the Terrain layer.
    /// </summary>
    public class ARTerrainInteractorSpawn : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The AR ray interactor that determines where to spawn the object.")]
        XRRayInteractor m_ARInteractor;

        /// <summary>
        /// The AR ray interactor that determines where to spawn the object.
        /// </summary>
        public XRRayInteractor arInteractor
        {
            get => m_ARInteractor;
            set => m_ARInteractor = value;
        }

        [SerializeField]
        [Tooltip("The behavior to use to spawn objects.")]
        ObjectSpawner m_ObjectSpawner;

        /// <summary>
        /// The behavior to use to spawn objects.
        /// </summary>
        public ObjectSpawner objectSpawner
        {
            get => m_ObjectSpawner;
            set => m_ObjectSpawner = value;
        }

        [SerializeField]
        [Tooltip("Layer mask for Terrain layer.")]
        LayerMask m_TerrainLayerMask;

        /// <summary>
        /// The input used to trigger spawn action.
        /// </summary>
        [SerializeField]
        XRInputButtonReader m_SpawnObjectInput = new XRInputButtonReader("Spawn Object");

        bool m_AttemptSpawn;

        void OnEnable()
        {
            m_SpawnObjectInput.EnableDirectActionIfModeUsed();
        }

        void OnDisable()
        {
            m_SpawnObjectInput.DisableDirectActionIfModeUsed();
        }

        void Start()
        {
            if (m_ObjectSpawner == null)
#if UNITY_2023_1_OR_NEWER
                m_ObjectSpawner = FindAnyObjectByType<ObjectSpawner>();
#else
                m_ObjectSpawner = FindObjectOfType<ObjectSpawner>();
#endif

            if (m_ARInteractor == null)
            {
                Debug.LogError("Missing AR Interactor reference, disabling component.", this);
                enabled = false;
            }
        }

        void Update()
        {
            // If the user triggered the spawn input (select or button press)
            if (m_SpawnObjectInput.ReadWasPerformedThisFrame())
            {
                Debug.unityLogger.Log("Spawning object", this);
                // Perform the raycast
                if (m_ARInteractor.TryGetCurrentARRaycastHit(out var arRaycastHit))
                {
                    Debug.unityLogger.Log("fired object to spawn", this);
                    // Check if the hit is on the Terrain layer
                    if ((m_TerrainLayerMask.value & (1 << arRaycastHit.trackable.gameObject.layer)) == 0)
                        return;  // If not on Terrain layer, don't spawn
                    
                    Debug.unityLogger.Log("Reached ! :", arRaycastHit.trackable.gameObject.layer);
                    // Get the position and normal from the raycast hit pose
                    Vector3 hitPosition = arRaycastHit.pose.position; 
                    Vector3 hitNormal = arRaycastHit.pose.rotation * Vector3.up;  // The normal is the up direction in the rotation of the pose

                    // Spawn the object at the hit position with the correct surface normal
                    Debug.DrawRay(hitPosition, hitNormal, Color.red,50f);
                    m_ObjectSpawner.TrySpawnObject(hitPosition, hitNormal);
                }
            }
        }
    }
}
#endif
