using UnityEngine;

namespace Platformer.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public float bulletSpeed = 10f; // Set the speed of the bullet
        public abstract void Shoot(GameObject bulletPrefab, Transform firePoint);
    }
}