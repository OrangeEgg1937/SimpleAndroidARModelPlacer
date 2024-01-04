using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{
    enum ControlOption
    {
        none = 0,
        positionX = 1,
        positionY = 2,
        positionZ = 3,
        rotationX = 4,
        rotationY = 5,
        rotationZ = 6,
        scale = 7,
    }

    enum ButtonAction
    {
        PLUS = 0,
        MINS = 1,
    }

    [SerializeField]
    private ControlOption option = ControlOption.none;

    private ModelInfomation mModelInfo;
    private Button plus;
    private Button mins;
    private TextMeshProUGUI disaplyVal;
    [SerializeField]
    private TMP_InputField userDefine;
    private float rotateRatio = 1.0f;
    private ActionMessage message;

    // initial the member
    private void Awake()
    {
        plus = gameObject.transform.GetChild(0).GetComponent<Button>();
        mins = gameObject.transform.GetChild(1).GetComponent<Button>();
        disaplyVal = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        message = FindFirstObjectByType<ActionMessage>();

        mModelInfo = Resources.Load<ModelInfomation>("CharacterModel/ModelInfo");

        if (option == ControlOption.rotationX || option == ControlOption.rotationY || option == ControlOption.rotationZ)
        {
            plus.onClick.AddListener(delegate { EditVal(option, 1.0f); });
            mins.onClick.AddListener(delegate { EditVal(option, -1.0f); });
        }
        else
        {
            plus.onClick.AddListener(delegate { EditVal(option, mModelInfo.ratio); });
            mins.onClick.AddListener(delegate { EditVal(option, -mModelInfo.ratio); });
        }


        DisplayData(option);
    }

    private void Update()
    { 

    }

    public void UpdateRotateRatio(string arg0)
    {
        if (arg0 == null) { return; }
        if (float.TryParse(arg0, out rotateRatio))
        {
            print(rotateRatio);
            message.SetMessage(rotateRatio.ToString());
        }
        else
        {
            message.SetMessage("Fail to convert");
        }
    }

    private void DisplayData(ControlOption option)
    {
        switch (option)
        {
            case ControlOption.none: break;
            case ControlOption.positionX: disaplyVal.SetText(mModelInfo.pos.x.ToString("0.00")); break;
            case ControlOption.positionY: disaplyVal.SetText(mModelInfo.pos.y.ToString("0.00")); break;
            case ControlOption.positionZ: disaplyVal.SetText(mModelInfo.pos.z.ToString("0.00")); break;
            case ControlOption.rotationX: disaplyVal.SetText(mModelInfo.rotate.x.ToString("0.00")); break;
            case ControlOption.rotationY: disaplyVal.SetText(mModelInfo.rotate.y.ToString("0.00")); break;
            case ControlOption.rotationZ: disaplyVal.SetText(mModelInfo.rotate.z.ToString("0.00")); break;
            case ControlOption.scale    : disaplyVal.SetText(mModelInfo.scale.x.ToString("0.00")); break;
        }
    }

    private void EditVal(ControlOption option, float val)
    {
        switch (option)
        {
            case ControlOption.none: break;
            case ControlOption.positionX: mModelInfo.pos.x += val ; break;
            case ControlOption.positionY: mModelInfo.pos.y += val ; break;
            case ControlOption.positionZ: mModelInfo.pos.z += val ; break;
            case ControlOption.rotationX: mModelInfo.rotate.x += rotateRatio * val; break;
            case ControlOption.rotationY: mModelInfo.rotate.y += rotateRatio * val; break;
            case ControlOption.rotationZ: mModelInfo.rotate.z += rotateRatio * val; break;
            case ControlOption.scale: mModelInfo.scale += new Vector3(val, val, val); break;
        }

        DisplayData(option);
    }
}
