using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject skeleParent;
    Transform bar;
    float currentHP;
    float healthPercent;

	// Use this for initialization
	void Start () {
        Transform bar = gameObject.transform;

    }

    // Update is called once per frame
    void Update () {
        currentHP = skeleParent.GetComponent<SkeleController>().health;

        healthPercent = currentHP / 100f;

        Vector3 scale = new Vector3(healthPercent, 1f);

        gameObject.transform.localScale = scale;
        



    }
}
