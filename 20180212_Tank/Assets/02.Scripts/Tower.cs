using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float fireSpd = 3f;
    private float fireCounter = 0f;
    private bool canFire = true;
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private GameObject projectile;

    private bool isLockedOn = false;

    public bool LockedOn
    {
        get { return isLockedOn; }
        set { isLockedOn = value; }
    }

    private void Update()
    {
        if (LockedOn && canFire)
        {
            StartCoroutine(Fire());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("TankInRange", true);
        }
        //if (other.tag == "Enemy")
        //{
        //    Debug.Log(other.name);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("TankInRange", false);
        }
    }

    private void FireProjectile()
    {
        GameObject bullet = Instantiate(projectile, muzzle.position, muzzle.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(muzzle.up * 300);
    }

    private IEnumerator Fire()
    {
        canFire = false;
        FireProjectile();
        while (fireCounter < fireSpd)
        {
            fireCounter += Time.deltaTime;
            yield return null;
        }
        canFire = true;
        fireCounter = 0f;
    }
}
