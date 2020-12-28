using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour
{
    
    public Transform[] waypoints;

    private int _waypointIndex;

    public bool changePosition;
    
    // Start is called before the first frame update
    void Start() {
        changePosition = false;
        Random random = new Random();
        _waypointIndex = random.Next(0, 11);
        if (_waypointIndex < 3) gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(3, 0);
        else gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 3);
        transform.position = waypoints[_waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (changePosition) 
            ChangePosition();
    }

    private void ChangePosition() {
        Random random = new Random();
        _waypointIndex = random.Next(0, 11);
        if (_waypointIndex < 3) gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(3, 0);
        else gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 3);
        transform.position = waypoints[_waypointIndex].transform.position;
        changePosition = false;
    }
}
