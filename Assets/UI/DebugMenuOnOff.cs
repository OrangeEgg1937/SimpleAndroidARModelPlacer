using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenuOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject debugMenu;
    bool isOn = true;

    public void OnClickAction()
    {
        RectTransform location = debugMenu.GetComponent<RectTransform>();
        if (isOn)
        {
            location.transform.localPosition = new Vector3Int(-9999, -9999, -9999);
            isOn = false;
        }
        else
        {
            location.transform.localPosition = new Vector3Int(0, 0, 0);
            isOn = true;
        }
    }
}
