﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    //variables
    [SerializeField] Rigidbody bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletSpawn;

    private float timeLastFired = 0f;
    private bool firing = false;

    // Update is called once per frame
    void Update()
    {
        float timeSinceLastFired = Time.time - timeLastFired;

        //calculates true or false
        bool canFire = timeSinceLastFired >= (1 / fireRate);

        //fire if Fire1 is pressed
        if (Input.GetButton("Fire1") && canFire)
        {
            BulletSpawn();
        }
    }

    //spawn bullet at specified point and launch it at specified velocity
    public void BulletSpawn()
    {
        Rigidbody instantiatedBullet = Instantiate(bullet, this.bulletSpawn.transform.position, this.bulletSpawn.transform.rotation);

        instantiatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));

        timeLastFired = Time.time;
    }
}
