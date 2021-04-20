using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// /Sounds in this game are downloaded from - ZapSplat
/// </summary>
public class maintainSound : MonoBehaviour
{

    private static maintainSound instance = null;
    public static maintainSound Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
