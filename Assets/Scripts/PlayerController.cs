using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float speed = 10f;
    [Tooltip("In m")][SerializeField] float xRange  = 5.5f; 
    [Tooltip("In m")][SerializeField] float yRange = 3.5f;
    [SerializeField] GameObject[] guns;

    [Header("Position")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;
    bool controlsEnabled = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(controlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }     
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        foreach (GameObject gun in guns) 
        {
            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                gun.SetActive(true);
            }
            else
            {
                gun.SetActive(false);
            }
        }
    }

    private void StopMovement()
    {
        controlsEnabled = false;
    }
}
