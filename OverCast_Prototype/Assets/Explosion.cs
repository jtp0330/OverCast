using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float life;
    // Update is called once per frame
    private void Start()
    {
        Invoke("DestroyExplode", life);
    }
    void DestoryExplode()
    {
        Destroy(gameObject);
    }
}
