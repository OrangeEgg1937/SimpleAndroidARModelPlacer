using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    private ARRaycastManager m_RaycastManager;
    private ARPlaneManager m_PlaneManager;

    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        m_PlaneManager = GetComponent<ARPlaneManager>();
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
/*        // no touch 
        if (Input.touchCount == 0) return;

        // Handle screen touches
        Touch userTouch = Input.GetTouch(0);

        if(userTouch.phase == TouchPhase.Began) { return; }

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Only returns true if there is at least one hit
            print("Touch plane!");

            Instantiate(prefab, m_Hits[0].pose.position, Quaternion.identity);
        }*/
    }
}
