using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonTextManager : MonoBehaviour {
    public TwitchChat GameManager;
    public TextMesh twitchName;

    // Use this for initialization
    void Start () {
        updateText();

    }

    // Update is called once per frame
    void Update () {

	}

    void updateText()
    {


        twitchName.text = TwitchChat.lastName;


    }
}
