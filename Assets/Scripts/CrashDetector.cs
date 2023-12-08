using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashReloadTimer = 0.5f;
    [SerializeField] ParticleSystem bumpEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            Debug.Log("Ouch!");
            hasCrashed = true;
            FindObjectOfType<PlayerController>().disableControls();
            bumpEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashReloadTimer);           
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
