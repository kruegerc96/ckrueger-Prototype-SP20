using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    //variables
    [SerializeField] Rigidbody bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] GameObject EnemyBulletSpawn;

    private float timeLastFired = 0f;
    private bool firing = false;

    // Update is called once per frame
    void Update()
    {
        float timeSinceLastFired = Time.time - timeLastFired;

        //calculates true or false
        bool canFire = timeSinceLastFired >= (1 / fireRate);

        //begin firing if raycast from targetPlayer hits the player
        if (GetComponent<targetPlayer>().canSeePlayer && canFire)
        {
            BulletSpawn();
        }
    }

    //spawn bullet at specified point and launch it at specified velocity
    public void BulletSpawn()
    {
        Rigidbody instantiatedBullet = Instantiate(bullet, this.EnemyBulletSpawn.transform.position, this.EnemyBulletSpawn.transform.rotation);

        instantiatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));

        timeLastFired = Time.time;
    }
}
