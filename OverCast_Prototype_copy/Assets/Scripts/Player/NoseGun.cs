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

    private void Awake()
    {
        //shootSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }
    }

    void Shoot()
    {
        am.getShoots().Play();
        animator.SetTrigger("Fire");
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

}
