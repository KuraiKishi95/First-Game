using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Shoot();
    //    }
    //}

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
