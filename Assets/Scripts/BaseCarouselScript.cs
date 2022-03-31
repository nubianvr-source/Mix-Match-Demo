using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BaseCarouselScript : MonoBehaviour
{
    public RectTransform[] images;
    public ScriptableImage sImage;
    /// <summary>
    /// For background, the groundNumber would be 0;
    /// For middleground, the groundNumber would be 1;
    /// For foreground, the groundNumber would be 2;
    /// </summary>
    [SerializeField]
    private int groundNumber;
    public RectTransform view_window;

    private bool  canSwipe;
    private float image_width;
    private float lerpTimer;
    private float lerpPosition;
    private float mousePositionStartX;
    private float mousePositionEndX;
    private float dragAmount;
    private float screenPosition;
    private float lastScreenPosition;

    /// <summary>
    /// Space between images.
    /// </summary>
    public  float image_gap = 30;
    public int swipeThrustHold = 150;
    [HideInInspector]
    /// <summary>
    /// The index of the current image on display.
    /// </summary>
    public int currentIndex;
    
    private CanvasGroup canvas;

    private void Awake()
    {
        //Get canvas object present in the scene...
        canvas = gameObject.GetComponent<CanvasGroup>();
    }


    #region mono
    // Use this for initialization
    public virtual void Start ()
    {
        currentIndex = 0;
        image_width = view_window.rect.width;
        switch(groundNumber)
        {
            case 0:
                for (int i = 0; i <= images.Length - 1; i++)
                {
                    images[i].GetComponent<Image>().sprite = sImage.backgroundImages[i];
                }
                break;

            case 1:
                for (int i = 0; i <= images.Length - 1; i++)
                {
                    images[i].GetComponent<Image>().sprite = sImage.middlegroundImages[i];
                }
                break;

            case 2:
                for (int i = 0; i <= images.Length - 1; i++)
                {
                    images[i].GetComponent<Image>().sprite = sImage.foregroundImages[i];
                }
                break;

            default:
                break;
        }

        
        for (int i = 1; i < images.Length; i++)
        {
            //Set the anchored point of images of index 1 and above on the x- axis to the sum of the image width and image gap(Distance from the origin) multiplied by the index value...
            images[i].anchoredPosition = new Vector2(((image_width + image_gap) * i), 0);
        }
       
    }
    

    // Update is called once per frame
    public virtual void Update () {

        //Check if the canvas object is set to interactable...
        if (canvas.interactable)
        {

            lerpTimer = lerpTimer + Time.deltaTime;

            if (lerpTimer < 0.333f)
            {
                screenPosition = Mathf.Lerp(lastScreenPosition, lerpPosition * -1, lerpTimer * 3);
                lastScreenPosition = screenPosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                canSwipe = true;
                mousePositionStartX = Input.mousePosition.x;
            }


            if (Input.GetMouseButton(0))
            {
                if (canSwipe)
                {
                    mousePositionEndX = Input.mousePosition.x;
                    dragAmount = mousePositionEndX - mousePositionStartX;
                    screenPosition = lastScreenPosition + dragAmount;
                }
            }

            if (Mathf.Abs(dragAmount) > swipeThrustHold && canSwipe)
            {
                canSwipe = false;
                lastScreenPosition = screenPosition;
                if (currentIndex < images.Length)
                    OnSwipeComplete();
                else if (currentIndex == images.Length && dragAmount < 0)
                    lerpTimer = 0;
                else if (currentIndex == images.Length && dragAmount > 0)
                    OnSwipeComplete();
            }

            for (int i = 0; i < images.Length; i++)
            {
                images[i].anchoredPosition = new Vector2(screenPosition + ((image_width + image_gap) * i), 0);
            }
        }
    }
    #endregion


    #region private methods
    public virtual void OnSwipeComplete()
    {
        lastScreenPosition = screenPosition;
        //If user swipes left...
        if (dragAmount > 0)
        {
            if (dragAmount >= swipeThrustHold)
            {
                if (currentIndex == 0)
                {
                    lerpTimer = 0; lerpPosition = 0;
                }
                else
                {
                    currentIndex--;
                    lerpTimer = 0;
                    if (currentIndex < 0)
                        currentIndex = 0;
                    lerpPosition = (image_width + image_gap) * currentIndex;
                }
            }
            else
            {
                lerpTimer = 0;
            }
        }
        //If user swipes right...
        else if (dragAmount < 0)
        {
            if (Mathf.Abs(dragAmount) >= swipeThrustHold)
            {
                if (currentIndex == images.Length-1)
                {
                    lerpTimer = 0;
                    lerpPosition = (image_width + image_gap) * currentIndex;
                }
                else
                {
                    lerpTimer = 0;
                    currentIndex++;
                    lerpPosition = (image_width + image_gap) * currentIndex;
                }
            }
            else
            {
                lerpTimer = 0;
            }
        }
        dragAmount = 0;

    }
    #endregion



    #region public methods
    public void GoToIndex(int value)
    {
        currentIndex = value;
        lerpTimer = 0;
        lerpPosition = (image_width + image_gap) * currentIndex;
        screenPosition = lerpPosition * -1;
        lastScreenPosition = screenPosition;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].anchoredPosition = new Vector2(screenPosition + ((image_width + image_gap) * i), 0);
        }
    }

    public void GoToIndexSmooth(int value)
    {
        currentIndex = value;
        lerpTimer = 0;
        lerpPosition = (image_width + image_gap) * currentIndex;
    }

    public int GetImagePoint()
    {
        if(groundNumber == 0)
        {
            return sImage.backgroundImagePoints[currentIndex];
        }
        else if(groundNumber == 1)
        {
            return sImage.middlegroundImagePoints[currentIndex];
        }
        else
        {
            return sImage.foregroundImagePoints[currentIndex];
        }
    }
    #endregion
    
}
