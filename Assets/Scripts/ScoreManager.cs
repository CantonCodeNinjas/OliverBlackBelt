using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static int globalScore;
    public Transform player;
    public Text scoreText;
    

    private void Start()
    {
        GameManager.globalScore = 0;
        UpdateScoreText();
        globalScore = 0;
    }
    
    private void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Knife");
        GameObject.FindGameObjectsWithTag("Scissors");
        GameObject.FindGameObjectsWithTag("Drop");
 
        foreach (GameObject obj in objects)
        {
            if (!IsObjectInView(obj))
            {
                globalScore++;
                UpdateScoreText();
                PrintScore();
            }
        }
    }

    private bool IsObjectInView(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.isVisible;
        }
        return false;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + globalScore.ToString();
    }

    public void PrintScore()
    {
        print("Score: " + globalScore);
    }
}