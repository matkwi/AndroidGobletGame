using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestrictions : MonoBehaviour {
    
    [SerializeField]
    private float topLimit;
    [SerializeField]
    private float bottomLimit;
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z);
    }
}
