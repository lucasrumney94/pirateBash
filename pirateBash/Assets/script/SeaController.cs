using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour
{

	public List<GameObject> SeaTiles;

    public float seaTilesDim = 6.0f;
	public int seaWidth = 100;
	public int seaLength = 100;
	public float SeaHeight = 1.0f;
    public float SeaSpeed = 1.0f;

    public List<GameObject> Islands;
    [Range(0,100)]
    public float islandChance =4.0f;

    public List<GameObject> boats;
    public int numberOfBoats;
    public Vector3 minSpawnPos;
    public Vector3 maxSpawnPos;


    // Use this for initialization
    void Start () 
	{
        //Debug.Log("start start");
        for (int i=0; i<seaLength; i++)
		{
			for (int j=0; j<seaWidth; j++)
			{
                if (Random.Range(0, 100) <= islandChance)
                {
                    GameObject.Instantiate(Islands[Random.Range(0, Islands.Count)], new Vector3(i * seaTilesDim, -10.0f, j * seaTilesDim), Quaternion.identity, transform);
                }

                GameObject.Instantiate(SeaTiles[Random.Range(0, SeaTiles.Count)], new Vector3(i * seaTilesDim, 0.0f, j * seaTilesDim), Quaternion.identity, transform);

			}
		}


        for (int k = 0; k < numberOfBoats; k++)
        {
            GameObject.Instantiate(boats[Random.Range(0, boats.Count)], new Vector3(Random.Range(minSpawnPos.x, maxSpawnPos.x), 5.0f, Random.Range(minSpawnPos.z, maxSpawnPos.z)), Quaternion.identity, transform);

        }
        //Debug.Log("start end");

    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
