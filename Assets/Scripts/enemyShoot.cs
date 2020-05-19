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

    [SerializeField]
    private int enemyTargetingRange;

    private GameObject PlayerCenterMass;

    private Collider PlayerCollider;

    public Transform target;
    public Transform EnemyBulletSpawnTransform;

    public bool canSeePlayer;

    private void Start()
    {
        PlayerCollider = GameObject.Find("Player").GetComponent<CapsuleCollider>();
        PlayerCenterMass = GameObject.Find("CenterMass");
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerCenterMass.transform;
        transform.LookAt(target);

        CheckRaycastHit();

        float timeSinceLastFired = Time.time - timeLastFired;

        //calculates true or false
        bool canFire = timeSinceLastFired >= (1 / fireRate);

        //begin firing if raycast from targetPlayer hits the player
        if (canSeePlayer && canFire)
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

    //check if raycast hits the PlayerCollider
    private void CheckRaycastHit()
    {
        RaycastHit hit;

        //specify that it needs to hit the PLAYER'S collider
        if (Physics.Raycast(this.EnemyBulletSpawn.transform.position, this.EnemyBulletSpawn.transform.TransformDirection(Vector3.up), out hit, enemyTargetingRange) && (hit.collider == PlayerCollider))
        {
            Debug.DrawRay(EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);

            canSeePlayer = true;
        }
        else
        {
            Debug.DrawRay(EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.TransformDirection(Vector3.up) * 1000, Color.white);

            canSeePlayer = false;
        }
    }
}
