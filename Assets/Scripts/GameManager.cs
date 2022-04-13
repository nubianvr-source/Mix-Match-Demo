using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SetObjects[] questionSetImages;
    private static int setImageIndex = 0;
    [SerializeField]
    private BaseCarouselScript background;
    [SerializeField]
    private BaseCarouselScript middleground;
    [SerializeField]
    private BaseCarouselScript foreground;

    [HideInInspector]
    public int totalPoints = 0;

    public static GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        //SoundManager.instance.PlaySFX("Swipe #1");
        if (gameManager != this || gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameManager);
        }
        DontDestroyOnLoad(gameManager);

        background.setImages = questionSetImages[setImageIndex];
        middleground.setImages = questionSetImages[setImageIndex];
        foreground.setImages = questionSetImages[setImageIndex];
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
        setImageIndex++;
        if (setImageIndex > (questionSetImages.Length - 1))
            setImageIndex = 0;
        Debug.Log("Current Image Index: " + setImageIndex);
        background.setImages = questionSetImages[setImageIndex];
        middleground.setImages = questionSetImages[setImageIndex];
        foreground.setImages = questionSetImages[setImageIndex];
    }
}
