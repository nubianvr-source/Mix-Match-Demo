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
    //Commentary clips... Like Hmmm! Ahhhh! Ouuhhh!... Something like that...
    //public AudioClip[] audioClips;
    //public Sound[] audioClips;
    public string descriptionText;
    //public AudioClip descriptionAudio;
    public Sound descriptionAudio;
}
