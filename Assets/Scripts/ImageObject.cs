using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Image Object", menuName ="Scriptable Objects/Image Object")]
public class ImageObject : ScriptableObject
{
    public Sprite image;
    public int imagePoint = 0;
    public AudioClip[] audioClips;
    public TMP_Text descriptionText;
    public AudioClip descriptionAudio;
}
