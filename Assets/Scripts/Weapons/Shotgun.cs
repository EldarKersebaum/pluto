using UnityEngine;

namespace Platformer.Weapons
{
    public class Shotgun : Weapon
    {
        public GameObject bulletPrefab;
        override public void Shoot(GameObject bulletPrefab, Transform firepoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = firepoint.right * bulletSpeed;


            GameObject bulletUp = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D bulletBodyUp = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = (firepoint.right + firepoint.up) * bulletSpeed;

            GameObject bulletDown = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D bulletBodyDown = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = (firepoint.right + firepoint.up * -1) * bulletSpeed;
        }
    }
}