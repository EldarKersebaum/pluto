using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bulletPrefab;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.controlEnabled && Input.GetButtonDown("Fire1")){
            Instantiate(bulletPrefab, this.gameObject.transform.position, playerController.transform.rotation);
        }
    }
}
