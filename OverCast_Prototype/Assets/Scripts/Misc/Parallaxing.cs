using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{   
    public Transform[] backgrounds;     //list of all backgrounds and foregrounds to be parallaxed
    private float[] parallaxScales;     //proportion of camera's movement to move the background by
    public float smoothing = 1;         //how smooth parallax is going to be; make sure to set > 0
    private Transform cam;              //main camera transform
    private Vector3 previousCamPos;     //position of camera iin previous frame

    //Awake Method is called before Start, but after all variables are setup
    //Great for references
    void Awake()
    {
        //setup the camera reference
        cam = Camera.main.transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        //previous frame had the current frame's camera position
        previousCamPos = cam.position;
        //assiging corresponding parallax scales
        parallaxScales = new float[backgrounds.Length]; 
        //loop trhough parallaxes
        for(int i =0; i < backgrounds.Length; i++)
        {
            //going through each background and asigning each background with corresponding 
            //parallax
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //for each background
        for(int i = 0; i < backgrounds.Length; i++)
        {
            //parallax is the opposite of the camera movement
            //because the previous frame is mutiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target x position (current position) + the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position(background current position) with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fate between current positon and target posiiton using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        //set previous cam posiiton to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
