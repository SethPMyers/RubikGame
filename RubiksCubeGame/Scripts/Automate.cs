using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{

    public static List<string> moveList = new List<string>() { };
    private readonly List<string> allMoves = new List<string>() { "U", "D", "L", "R", "F", "B", "U2", "D2", "L2", "R2", "F2", "B2", "U'", "D'", "L'", "R'", "F'", "B'" };
    private CubeState cubeState;
    private ReadCube readCube;
    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started)
        {
            DoMove(moveList[0]);
            moveList.Remove(moveList[0]);
        }
    }

    public void Shuffle()
    {
        List<string> moves = new List<string>();
        int shuffleLength = Random.Range(16, 30);
        for(int i = 0; i < shuffleLength; i++)
        {
            int randomMove = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
        }
        moveList = moves;
    }

    void DoMove(string move)
    {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if(move == "U")
        {
            RoatateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RoatateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RoatateSide(cubeState.up, 180);
        }
        if (move == "D")
        {
            RoatateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RoatateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RoatateSide(cubeState.down, 180);
        }
        if (move == "L")
        {
            RoatateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RoatateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RoatateSide(cubeState.left, 180);
        }
        if (move == "R")
        {
            RoatateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RoatateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RoatateSide(cubeState.right, 180);
        }
        if (move == "F")
        {
            RoatateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RoatateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RoatateSide(cubeState.front, 180);
        }
        if (move == "B")
        {
            RoatateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RoatateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RoatateSide(cubeState.back, 180);
        }
    }

    void RoatateSide(List<GameObject> side, float angle)
    {
        PivotRotation pr = side[4].transform.parent.transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
