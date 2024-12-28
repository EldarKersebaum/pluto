using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Bullet collided with:" + hitInfo.name);
        if (hitInfo.name == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(hitInfo.gameObject);
        }
        if (hitInfo.name == "Level")
            Destroy(this.gameObject);
    }
}
