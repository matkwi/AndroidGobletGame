using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
    
    private float moveSpeed = 20f;

    private int waypointIndex;

    [HideInInspector]
    public bool Animate;

    [HideInInspector]
    public Vector3 StartPoint;
    
    [HideInInspector]
    public Vector3 EndPoint;
    
    private Images images;

    private bool StartPointSet;

    // Start is called before the first frame update
    void Start() {
        StartPointSet = false;
        Animate = false;
    }

    // Update is called once per frame
    void Update() {
            if (Animate) DoAnimation();
        }

    private void DoAnimation() {
        if (!StartPointSet) {
            transform.position = StartPoint;
            StartPointSet = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, 
            EndPoint,
            moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, EndPoint) < 0.001f) {
            transform.position = new Vector3((float) 4.83,(float) 8.92,0);
            Player.Animated = true;
            Animate = false;
            StartPointSet = false;
        }
        //images.SetKeyAnimationActive(false);
    }
}
