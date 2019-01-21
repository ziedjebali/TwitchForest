using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonTextManager : MonoBehaviour {

    public TextMesh damageText;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        updateText();
	}

    void updateText()
    {
        damageText.text = transform.parent.gameObject.GetComponent<SkeleController>().health.ToString();
    }
}
