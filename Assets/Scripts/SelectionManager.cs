using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    //Just Testing
    public CanvasGroup background;

    public CanvasGroup middle;

    public CanvasGroup foreground;

    public void reset()
    {
        SceneManager.LoadScene(0);
    }


}
