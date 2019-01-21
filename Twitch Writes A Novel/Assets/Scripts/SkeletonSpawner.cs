using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour {

    public GameObject SkeletronPrefabRed;

    public GameObject SkeletronPrefabBlue;

    public GameObject RedskeleSpawn;
    public GameObject BlueskeleSpawn;


    // Use this for initialization
    void Start () {



    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SpawnSkeletonRed()
    {
        Instantiate(SkeletronPrefabRed, RedskeleSpawn.transform.position, Quaternion.identity);

    }

    public void SpawnSkeletonBlue()
    {
        Instantiate(SkeletronPrefabBlue, BlueskeleSpawn.transform.position, Quaternion.identity);

    }
}
