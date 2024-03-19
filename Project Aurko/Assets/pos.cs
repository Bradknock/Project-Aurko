using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos : MonoBehaviour
{

    Vector3 vec;
    public Camera cam;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vec = new Vector3(obj.transform.position.x + 10, obj.transform.position.y + 5, obj.transform.position.z -10);

        cam.transform.position = vec;
    }
}
