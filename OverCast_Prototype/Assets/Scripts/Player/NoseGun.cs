using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseGun : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public Animator animator;
    //[SerializeField] AudioSource shootSound;
    [SerializeField]AudioManager am;
    //time for allowing player to shoot
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Awake()
    {
        //shootSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime; 
        }
    }

    void Shoot()
    {
        am.getShoots().Play();
        animator.SetTrigger("Fire");
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

}
