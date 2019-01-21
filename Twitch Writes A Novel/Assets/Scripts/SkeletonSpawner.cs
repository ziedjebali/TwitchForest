using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour {

    public GameObject SkeletronPrefab;
    public Transform skeleSpawn;



	// Use this for initialization
	void Start () {

        Instantiate(SkeletronPrefab, transform.position, Quaternion.identity);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
