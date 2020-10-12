using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    [HideInInspector] 
    public int iterator = 0;

    public bool moveAllowed = false;

    private string arrowDirection;

	// Use this for initialization
	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
    }
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }   
        if (moveAllowed)
            Move();
	}
    
    private void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            setArrowDirection(hit.collider.gameObject.name);
        }
    }    

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1) {
            transform.position = Vector3.MoveTowards(transform.position, 
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position) {
                if (transform.position == waypoints[0].transform.position) {
                    waypointIndex += 0;
                    if (arrowDirection.Equals("ArrowDown1")) {
                        waypointIndex += 57;
                        iterator += 1;
                    }
                    if (arrowDirection.Equals("ArrowRight1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[57].transform.position) {
                    waypointIndex -= 26;
                    iterator += 1;
                }
                else if (transform.position == waypoints[19].transform.position) {
                    waypointIndex += 0;
                    if (arrowDirection.Equals("ArrowDown2")) {
                        waypointIndex = 58;
                        iterator += 1;
                    }
                    if (arrowDirection.Equals("ArrowUp1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[66].transform.position) {
                    waypointIndex = 19;
                    iterator += 1;
                }
                else if (transform.position == waypoints[37].transform.position) {
                    waypointIndex += 0;
                    if (arrowDirection.Equals("ArrowDown3")) {
                        waypointIndex = 67;
                        iterator += 1;
                    }
                    if (arrowDirection.Equals("ArrowLeft1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[75].transform.position) {
                    waypointIndex = 43;
                    iterator += 1;
                }
                else if (transform.position == waypoints[45].transform.position) {
                    waypointIndex += 0;
                    if (arrowDirection.Equals("ArrowRight2")) {
                        waypointIndex = 76;
                        iterator += 1;
                    }
                    if (arrowDirection.Equals("ArrowUp2")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[79].transform.position) {
                    waypointIndex = 50;
                    iterator += 1;
                }
                else if (transform.position == waypoints[56].transform.position) {
                    waypointIndex = 0;
                    iterator += 1;
                }
                else {
                    waypointIndex += 1;
                    iterator += 1;
                }
            }
        }
    }

    private void setArrowDirection(string direction) {
        arrowDirection = direction;
    }
    
}
