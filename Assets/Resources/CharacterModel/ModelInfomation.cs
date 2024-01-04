using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ModelInfo", menuName ="CustomModelInfo", order = 0)]
public class ModelInfomation : ScriptableObject
{
    public GameObject displayPrefab;

    [Header("Position:")]
    public Vector3 pos = Vector3.zero;

    [Header("Rotation")]
    public Vector3 rotate = Vector3.zero;

    [Header("Scale")]
    public Vector3 scale = Vector3.one;

    [Header("ratio")]
    public float ratio = 0.1f;
}
