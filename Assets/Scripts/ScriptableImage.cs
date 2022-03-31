using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Image", menuName ="Scriptable Objects/Scriptable Image")]
public class ScriptableImage : ScriptableObject
{
    public Sprite[] backgroundImages;
    public int[] backgroundImagePoints;
    public Sprite[] middlegroundImages;
    public int[] middlegroundImagePoints;
    public Sprite[] foregroundImages;
    public int[] foregroundImagePoints;
}
