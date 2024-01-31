using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Drop") && !collision.gameObject.CompareTag("Knife") && !collision.gameObject.CompareTag("Powerup"))
        {
            SceneManager.LoadScene(0);
        }
    }
}