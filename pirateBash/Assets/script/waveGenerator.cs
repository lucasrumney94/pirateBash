using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveGenerator : MonoBehaviour {

    private float waveHeight;
    private float waveSpeed;
    private float myRandomTimeSeed;

	// Use this for initialization
	void Start ()
    {
        waveHeight = gameObject.GetComponentInParent<SeaController>().SeaHeight;
        waveSpeed = gameObject.GetComponentInParent<SeaController>().SeaSpeed;
        myRandomTimeSeed = Random.Range(0.0f, 10.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, waveHeight*Mathf.Cos(myRandomTimeSeed+waveSpeed*(Time.time)), gameObject.transform.position.z);
	}
}
