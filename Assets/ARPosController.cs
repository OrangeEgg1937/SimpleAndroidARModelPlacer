using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class ARPosController : MonoBehaviour
{
    ARCameraManager cameraManager;
    XROrigin core;
    [SerializeField]
    TextMeshProUGUI displayText;
    LightEstimation currentLight = LightEstimation.None;

    private void Awake()
    {
        cameraManager = FindFirstObjectByType<ARCameraManager>();
        core = FindFirstObjectByType<XROrigin>();
    }

    // Update the camera val
    void Update()
    {
        displayText.SetText("Camera info:\n"
            + $"Offset:{core.CameraYOffset} "
            + "Light:" + cameraManager.currentLightEstimation + "\n");
    }

    public void SwitchLightEstimation()
    {
        switch (currentLight)
        {
            case LightEstimation.None:
                currentLight = LightEstimation.AmbientIntensity; break;
            case LightEstimation.AmbientIntensity:
                currentLight = LightEstimation.AmbientColor; break;
            case LightEstimation.AmbientColor:
                currentLight = LightEstimation.AmbientSphericalHarmonics; break;
            case LightEstimation.AmbientSphericalHarmonics:
                currentLight = LightEstimation.MainLightDirection; break;
            case LightEstimation.MainLightDirection:
                currentLight = LightEstimation.MainLightIntensity; break;
            case LightEstimation.MainLightIntensity:
                currentLight = LightEstimation.None; break;
            default: break;
        }

        cameraManager.requestedLightEstimation = currentLight;
    }

    public void SetCameraYOffset(string arg0)
    {
        float userOffset = core.CameraYOffset;
        if (arg0 == null) { return; }
        if (float.TryParse(arg0, out userOffset))
        {
            print(userOffset);
        }
        else
        {
            return;
        }
        core.CameraYOffset = userOffset;
    }

/*    public static T NextEnumValue<T>(T value) where T : struct, Enum
    {
        T[] values = (T[])Enum.GetValues(typeof(T));
        int currentIndex = Array.IndexOf(values, value);
        int nextIndex = (currentIndex + 1) % values.Length;

        return values[nextIndex];
    }*/
}
