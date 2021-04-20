using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] soundArray = GetComponents<AudioSource>();
        jumpSound = soundArray[0];
        shootSound = soundArray[1];
        //jumpSound = gameObject.AddComponent<AudioSource>();
        //shootSound = gameObject.AddComponent<AudioSource>();
    }

    public AudioSource getShoots()
    {
        return shootSound;
    }

    public AudioSource getJumps()
    {
        return jumpSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
