using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.UIElements;
using Platformer.Weapons;
using UnityEngine.Rendering.Universal;

public class FirePoint : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public PlayerController playerController;
    public int shootgunShotsFired = 0;
    public float timeSinceLastShotgunShot = 0f;

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
            playerController.equippedWeapon.Shoot(bulletPrefab, this.gameObject.transform);
            if (playerController.equippedWeapon is Shotgun)
            {
                playerController.move = 3 * -1 * new Vector2(this.gameObject.transform.right.x, this.gameObject.transform.right.y);
                playerController.velocity = 7 * -1 * new Vector2(this.gameObject.transform.right.x, this.gameObject.transform.right.y);
                playerController.controlEnabled = false;
                shootgunShotsFired = 1;
            }
        }
        if (shootgunShotsFired != 0)
        {
            timeSinceLastShotgunShot += Time.deltaTime;

            Debug.Log("Time since last shot:" + timeSinceLastShotgunShot);
            if (timeSinceLastShotgunShot > 0.05)
            {
                float angle = GetShootingAngle();
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
                playerController.equippedWeapon.Shoot(bulletPrefab, this.gameObject.transform);
                timeSinceLastShotgunShot = 0;
                shootgunShotsFired++;
                Debug.Log("Shotgun shots fired :" + shootgunShotsFired);
            }
            if (shootgunShotsFired == 5)
            {
                shootgunShotsFired = 0;
                playerController.controlEnabled = true;
                Debug.Log("Shotung reset");
            }
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
