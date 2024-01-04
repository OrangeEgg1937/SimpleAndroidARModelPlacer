using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoseController : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField]
    public ModelIndex action = ModelIndex.POSE_WINK;
    private ModelPlacer controller;

    private void Awake()
    {
        controller = FindFirstObjectByType<ModelPlacer>();
    }

    public void SetAction()
    {
        isActive = !isActive;
        controller.SetAnimation(action, isActive);
    }


}
