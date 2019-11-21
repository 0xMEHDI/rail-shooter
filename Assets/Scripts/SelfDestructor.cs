using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float selfDestructionDelay = 5f;

    void Start()
    {
        Destroy(gameObject, selfDestructionDelay);
    }
}
