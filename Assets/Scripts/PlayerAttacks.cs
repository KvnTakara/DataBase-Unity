using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject gun;
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate = 0.2f;
    float lastTimeShot = 0;

    [SerializeField] float slashRate = 0.5f;
    float lastTimeSlash = 0;

    #endregion

    #region Initialization

    void Update()
    {
        InputManager();
    }

    #endregion

    #region Functions

    void InputManager()
    {
        // Shoot Input.
        if (Input.GetButton("Fire1"))
        {
            if (lastTimeShot + fireRate <= Time.time)
            {
                lastTimeShot = Time.time;
                Shoot();
            }
        }

        // Slash Input.
        if (Input.GetButton("Fire2"))
        {
            if (lastTimeSlash + slashRate <= Time.time)
            {
                lastTimeSlash = Time.time;
                Slash();
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
    }

    void Slash()
    {
        
    }

    #endregion
}
