using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScriptableImage[] sImages;
    private static int sImageIndex = 0;
    [SerializeField]
    private RectTransform background;
    [SerializeField]
    private RectTransform middleground;
    [SerializeField]
    private RectTransform foreground;

    [HideInInspector]
    public int totalPoints = 0;

    public static GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != this || gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        background.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
        middleground.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
        foreground.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectImage(RectTransform image)
    {
        BaseCarouselScript temp = image.GetComponent<BaseCarouselScript>();
        if (temp)
        {
            totalPoints += temp.GetImagePoint();
            Debug.Log(totalPoints);
        }
    }

    public void ReloadScene(int buildIndex)
    {
        MoveToNextSequence();
        SceneManager.LoadScene(buildIndex);
    }

    public void MoveToNextSequence()
    {
        sImageIndex++;
        if (sImageIndex > (sImages.Length - 1))
            sImageIndex = 0;
        Debug.Log("Current Image Index: " + sImageIndex);
        background.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
        middleground.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
        foreground.GetComponent<BaseCarouselScript>().sImage = sImages[sImageIndex];
    }
}
