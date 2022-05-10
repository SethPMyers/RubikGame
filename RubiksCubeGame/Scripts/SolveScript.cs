using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CubeData
{
    Vector3 CubeHome;
    string CubeName;

    public CubeData(Vector3 cubeHome, string cubeName)
    {
        this.CubeHome = cubeHome;
        this.CubeName = cubeName;
    }
}
public class SolveScript : MonoBehaviour
{
    //public List<CubeData> CubeHomeData = new List<CubeData>();
    public Hashtable CubeHomeData = new Hashtable();
    public GameObject TextSolved;
    public GameObject TextNotSolved;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            // CubeData temp = new CubeData(Cube.transform.position, Cube.name);
            // CubeHomeData.Add(temp);
            CubeHomeData.Add(Cube.name, Cube.transform.position);

        }

    }

    public void checkSolved()
    {
        TextSolved.SetActive(false);
        TextNotSolved.SetActive(false);
        foreach (GameObject Cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            if (Vector3.Distance((Vector3)CubeHomeData[Cube.name], Cube.transform.position) > .1f)
            {
                Debug.Log("cube not solved");
                TextNotSolved.SetActive(true);
                return;
            }
        }
        Debug.Log("cube is solved");
        TextSolved.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
