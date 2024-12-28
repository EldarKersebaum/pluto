using UnityEngine;

namespace Platformer.Weapons
{
    public class Pistol : Weapon
    {
        public GameObject bulletPrefab;
        override public void Shoot(GameObject bulletPrefab, Transform firepoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = firepoint.right * bulletSpeed;
        }
    }
}