using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.transform.rotation.y == 0)
            rb.velocity = Vector2.right * speed;
        else
            rb.velocity = Vector2.left * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Debug.Log("Bullet collided with:" + hitInfo.name);
        if(hitInfo.name == "Enemy") {
            Destroy(this.gameObject);
            Destroy(hitInfo.gameObject);
        }
        if(hitInfo.name == "Level") 
            Destroy(this.gameObject);
    }
}
