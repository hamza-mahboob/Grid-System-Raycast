using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridSystem : MonoBehaviour
{
    public GameObject cube;
    public GameObject player;
    public const int rows = 10, cols = 10;
    private GameObject[,] cubes;
    private List<string> birds = new List<string>();
    Dictionary<int, string> birdsDictionary = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[rows, cols];
        //populate list
        birds.Add("Falcon");
        birds.Add("Crow");
        birds.Add("Eagle");
        birds.Add("Vulture");

        //populate dictionary
        birdsDictionary.Add(1, "Parrot");
        birdsDictionary.Add(2, "Peacock");
        birdsDictionary.Add(3, "Woodpecker");
        birdsDictionary.Add(4, "Dove");

        for (int i = 0; i < rows; i += 2)
        {
            for (int j = 0; j < cols; j += 2)
            {
                //instantiate cube grid
                cubes[i, j] = Instantiate(cube, new Vector3(i, 0, j), Quaternion.identity);

                //assign a random bird to a cube
                /*var randomBird = birds[Random.Range(0, birds.Count)];
                cubes[i, j].GetComponent<BirdOnCube>().setBird(randomBird);*/

                //text on cube
                /*cubes[i, j].GetComponentInChildren<TextMesh>().text = randomBird;*/

                //random bird text on cube using dictionary
                var randomBird = birdsDictionary[Random.Range(1, birds.Count)];
                cubes[i, j].GetComponentInChildren<TextMesh>().text = randomBird;

                //set text
                cubes[i, j].GetComponent<BirdOnCube>().setBird(randomBird);

                //set player position to first cube
                if (i == 0 && j == 0)
                    player.transform.position = cubes[i, j].transform.position + new Vector3(0, 1, 0);
            }
        }
    }

    public int getRows()
    {
        return rows;
    }

    public int getCol()
    {
        return cols;
    }
}