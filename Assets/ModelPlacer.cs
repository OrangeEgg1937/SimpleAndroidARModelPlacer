using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public enum ModelIndex
{
    POSE_WINK = 0,
    STAND_STANDARD = 1,
    STAND_SITDOWN = 2,
    POSE_V_HAND = 3,
}

public class ModelPlacer : MonoBehaviour
{
    // Game object of perview image
    [SerializeField]
    private GameObject perviewImage;
    [SerializeField]
    private SkinnedMeshRenderer animation;
    public bool showPreview = false;
    Dictionary<ModelIndex, int> modelMapping = new Dictionary<ModelIndex, int>();

    private void Awake()
    {
        ActionMapping();
    }

    public void TogglePerview()
    {
        perviewImage.SetActive(showPreview);
        showPreview = !showPreview;
    }

    private void ActionMapping()
    {
        modelMapping.Add(ModelIndex.POSE_WINK, 6);
        modelMapping.Add(ModelIndex.STAND_STANDARD, 28);
        modelMapping.Add(ModelIndex.POSE_V_HAND, 30);
        modelMapping.Add(ModelIndex.STAND_SITDOWN, 29);
    }

    private void Start()
    {
        PrintAnimation();
    }


    public void PrintAnimation()
    {
        Mesh m = animation.sharedMesh;
        for (int i = 0; i < m.blendShapeCount; i++)
        {
            string s = m.GetBlendShapeName(i);
            print("Blend Shape: " + i + " " + s);
        }
    }

    public void SetAnimation(ModelIndex action, bool isActive)
    {
        float set = isActive ? 100.0f : 0.0f;
        int index = 0;
        bool check = modelMapping.TryGetValue(action, out index);
        if (check == false) return;

        animation.SetBlendShapeWeight(index, set);
    }

}
