using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int health = 100;
    [SerializeField] int damagePerHit = 10;
    [SerializeField] int scorePerHit = 1000;


    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerCollider()
    {
        BoxCollider[] colliders = FindObjectsOfType<BoxCollider>();
        if (colliders.Length > 1)
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        health -= damagePerHit;
        CreateFX(0.5f);      
        DestroyShip();
    }

    private void DestroyShip()
    {
        if (health <= 0)
        {
            CreateFX(1.5f);
            scoreBoard.IncrementScorePetHit(scorePerHit);
            Destroy(gameObject);
        }
    }

    private void CreateFX(float scaleFactor)
    {
        GameObject fx = Instantiate(deathFX, transform.position, transform.rotation);
        fx.transform.parent = parent;
        fx.transform.localScale = new Vector3(fx.transform.localScale.x * scaleFactor, fx.transform.localScale.y * scaleFactor, fx.transform.localScale.z * scaleFactor);
    }
}
   