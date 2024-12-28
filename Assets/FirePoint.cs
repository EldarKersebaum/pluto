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

    public float bulletSpeed = 10f; // Set the speed of the bullet

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the Z position is 0 (or the same as your firepoint if in 3D)
        Vector3 direction = mousePosition - this.gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);
        if(playerController.controlEnabled && Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Set the velocity of the bullet towards the firepoint's direction
                rb.velocity = firepoint.right * bulletSpeed; // firepoint.right is the forward direction in 2D
            }
        }

    }
}
