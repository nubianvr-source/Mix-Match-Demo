using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Image", menuName ="Scriptable Objects/Scriptable Image")]
public class SetObjects: ScriptableObject
{
    public ImageObject[] backgroundImages;
    public ImageObject[] middlegroundImages;
    public ImageObject[] foregroundImages;
}
