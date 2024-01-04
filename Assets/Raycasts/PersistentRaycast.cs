using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PersistentRaycast : MonoBehaviour
{
    private ModelInfomation mModelInfo;
    private ARRaycastManager raycastManager;
    static List<ARRaycastHit> hitList = new List<ARRaycastHit>();
    public GameObject model;
    private Transform target;
    public bool isPlace = false;
    private ARRaycastHit currentLocked;

    // Get the debug message component
    ActionMessage message;

    // initial the AR raycast manager
    private void Awake()
    {
        target = model.transform;
        raycastManager = GetComponent<ARRaycastManager>();
        mModelInfo = Resources.Load<ModelInfomation>("CharacterModel/ModelInfo");
        message = FindFirstObjectByType<ActionMessage>();
        if (mModelInfo == null)
        {
            message.SetMessage("ERROR! Unable to find model information");
        }
        else
        {
            message.SetMessage("Model loaded!");
        }
    }

    void Update()
    {
        // preview image
        if (isPlace)
        {
            target.position = currentLocked.pose.position + mModelInfo.pos;
            target.rotation = currentLocked.pose.rotation;
            target.rotation = Quaternion.Euler(mModelInfo.rotate);
            target.localScale = mModelInfo.scale;
        }
        else
        {
            if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
                hitList,
                TrackableType.PlaneWithinPolygon
                ))
            {
                hitList.OrderBy(s => s.distance);
                target.position = hitList[0].pose.position + mModelInfo.pos;
                target.rotation = hitList[0].pose.rotation;
                target.rotation = Quaternion.Euler(mModelInfo.rotate);
                target.localScale = mModelInfo.scale;
            }
        }
    }

    public void PlaceModel()
    {   
        if (isPlace) { return; }
        isPlace = true;
        ModelPlacer modelPlacer = model.GetComponent<ModelPlacer>();
        modelPlacer.TogglePerview();
        currentLocked = hitList[0];
    }

    public void Reset()
    {
        if(!isPlace) { return; }
        ModelPlacer modelPlacer = model.GetComponent<ModelPlacer>();
        modelPlacer.TogglePerview();
        isPlace = false;
    }
}
