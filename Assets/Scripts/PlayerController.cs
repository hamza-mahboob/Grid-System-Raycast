using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string bird;
    public TextMesh birdText;
    GridSystem gridSystem;
    int xBound, zBound, distance;
    Ray leftRay, rightRay, forwardRay, backRay;
    RaycastHit leftHit, rightHit, forwardHit, backHit;
    bool canMoveLeft, canMoveRight, canMoveForward, canMoveBack;

    // Start is called before the first frame update
    void Start()
    {
        gridSystem = GameObject.Find("Plane/SpawnManager").GetComponent<GridSystem>();

        distance = 2;

        xBound = gridSystem.getRows() - 2;
        zBound = gridSystem.getCol() - 2;

    }

    // Update is called once per frame
    void Update()
    {
        canMoveBack = false;
        canMoveForward = false;
        canMoveLeft = false;
        canMoveRight = false;

        birdText.text = bird;

        //testing rays
        Debug.DrawRay(transform.position + new Vector3(0, -1, 0), Vector3.forward);
        Debug.DrawRay(transform.position + new Vector3(0, -1, 0), Vector3.back);
        Debug.DrawRay(transform.position + new Vector3(0, -1, 0), Vector3.right);
        Debug.DrawRay(transform.position + new Vector3(0, -1, 0), Vector3.left);

        //set rays
        leftRay = new Ray(transform.position + new Vector3(0, -1, 0), Vector3.left);
        rightRay = new Ray(transform.position + new Vector3(0, -1, 0), Vector3.right);
        forwardRay = new Ray(transform.position + new Vector3(0, -1, 0), Vector3.forward);
        backRay = new Ray(transform.position + new Vector3(0, -1, 0), Vector3.back);

        //shoot rays
        if (Physics.Raycast(leftRay, out leftHit, distance))
        {
            Debug.Log("Left hit!");

            if (leftHit.collider.CompareTag("Cube"))
            {
                canMoveLeft = true;
            }
        }

        if (Physics.Raycast(rightRay, out rightHit, distance))
        {
            Debug.Log("Right hit!");

            if (rightHit.collider.CompareTag("Cube"))
            {
                canMoveRight = true;
            }
        }

        if (Physics.Raycast(forwardRay, out forwardHit, distance))
        {
            Debug.Log("Forward hit!");

            if (forwardHit.collider.CompareTag("Cube"))
            {
                canMoveForward = true;
            }
        }

        if (Physics.Raycast(backRay, out backHit, distance))
        {
            Debug.Log("Back hit!");

            if (backHit.collider.CompareTag("Cube"))
            {
                canMoveBack = true;
            }
        }



        //left restricted
        /*        if (transform.position.x < 0)
                    transform.position = new Vector3(0, transform.position.y, transform.position.z);
                //right restricted
                if (transform.position.x > xBound)
                    transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
                //down restricted
                if (transform.position.z < 0)
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                //up restricted
                if (transform.position.z > zBound)
                    transform.position = new Vector3(transform.position.x, transform.position.y, zBound);*/

        //Player movement
        if (Input.GetKeyDown(KeyCode.W) && canMoveForward)
        {
            transform.Translate(new Vector3(0, 0, 2));
        }
        if (Input.GetKeyDown(KeyCode.S) && canMoveBack)
        {
            transform.Translate(new Vector3(0, 0, -2));
        }
        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            transform.Translate(new Vector3(-2, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            transform.Translate(new Vector3(2, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //display bird on cube
        bird = collision.gameObject.GetComponent<BirdOnCube>().getBird();
        Debug.Log(bird);
    }

}
