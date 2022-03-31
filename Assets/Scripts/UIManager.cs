using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + GameManager.gameManager.totalPoints;
        scoreText.gameObject.SetActive(true);
    }
}
