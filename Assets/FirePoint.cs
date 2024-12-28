using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.controlEnabled && Input.GetButtonDown("Fire1"))
        {
            float angle = GetShootingAngle();
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
            Debug.Log(angle);
            playerController.equippedWeapon.Shoot(bulletPrefab, this.gameObject.transform);
        }
    }

    private float GetShootingAngle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the Z position is 0 (or the same as your firepoint if in 3D)
        Vector3 direction = mousePosition - this.gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
