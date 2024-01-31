using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image[] hearts;
    private int currentLives = 3;

    private void Start()
    {
        currentLives = hearts.Length;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife") && currentLives > 0)
        {
            ReduceLives();
        }
    }

    private void ReduceLives()
    {
        if (currentLives > 0)
        {
            currentLives--;
            hearts[currentLives].enabled = false;

            if (currentLives == 0)
            {
                Debug.Log("Game Over!");
            }
        }
    }
}