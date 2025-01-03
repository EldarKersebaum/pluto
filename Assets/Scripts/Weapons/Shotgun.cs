using UnityEngine;

namespace Platformer.Weapons
{
    public class Shotgun : Weapon
    {
        public GameObject bulletPrefab;
        override public void Shoot(GameObject bulletPrefab, Transform firepoint)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position,
                    Quaternion.Euler(
                        firepoint.rotation.eulerAngles.x,
                        firepoint.rotation.eulerAngles.x,
                        firepoint.rotation.eulerAngles.z - 90));
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

                bulletBody.velocity = bulletSpeed * firepoint.right + firepoint.up * Random.Range(-5, 5);
                Debug.Log("Velocity: " + bulletBody.velocity.ToString());
            }

        }
    }
}