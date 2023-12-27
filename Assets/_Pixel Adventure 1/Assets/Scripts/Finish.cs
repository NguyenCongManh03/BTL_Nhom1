using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSoud;
    private bool levelCompleted = false;
    private void Start()
    {
        finishSoud = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "MaskDude" && !levelCompleted)
        {
            finishSoud.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +  1);
    }
}
