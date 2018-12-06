using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    char direction;
    Vector3 targetPos;

    void move()
    {
        targetPos = transform.position;
        if (Input.GetKeyDown("w")) { direction = 'n'; }
        else if (Input.GetKeyDown("s")) { direction = 's'; }
        else if (Input.GetKeyDown("d")) { direction = 'e'; }
        else if (Input.GetKeyDown("a")) { direction = 'w'; }

        if (direction == 'n') { targetPos.y++; }
        else if (direction == 's') { targetPos.y--; }
        else if (direction == 'e' ) { targetPos.x++; }
        else if (direction == 'w' ) { targetPos.x--; }
        transform.position = targetPos;
    }

    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0)) { move(); }

    }

}
