using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("StopMovement");       
        deathFX.SetActive(true);
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
