using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    //
    public Transform followTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the position of the camera to the x and y coordinates of the player object. 
        // The camera is a child object of the player, so the camera can track to the player object's position.
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
