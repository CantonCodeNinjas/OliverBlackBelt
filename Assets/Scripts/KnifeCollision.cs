using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeCollision : MonoBehaviour
{
    private int knifeCollisions = 0;
    private int collisionLimit = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            knifeCollisions++;
            if (knifeCollisions >= collisionLimit)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}