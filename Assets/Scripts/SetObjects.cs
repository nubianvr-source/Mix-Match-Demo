using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Image", menuName ="Scriptable Objects/Scriptable Image")]
public class SetObjects: ScriptableObject
{
    /*public Sprite[] backgroundImages;
    public int[] backgroundImagePoints;
    public Sprite[] middlegroundImages;
    public int[] middlegroundImagePoints;
    public Sprite[] foregroundImages;
    public int[] foregroundImagePoints;*/

    public ImageObject[] backgroundImagess;
    public ImageObject[] middlegroundImagess;
    public ImageObject[] foregroundImagess;
}
