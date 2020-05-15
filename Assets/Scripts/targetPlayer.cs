using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayer : MonoBehaviour
{
    [SerializeField]
    private int enemyTargetingRange;

    private GameObject PlayerCenterMass;
    private GameObject EnemyBulletSpawn;

    private Collider PlayerCollider;

    public Transform target;
    public Transform EnemyBulletSpawnTransform;

    public bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider = GameObject.Find("Player").GetComponent<CapsuleCollider>();
        PlayerCenterMass = GameObject.Find("CenterMass");

        EnemyBulletSpawn = GameObject.Find("Enemy Bullet Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerCenterMass.transform;
        transform.LookAt(target);

        CheckRaycastHit();
    }


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