using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour {

    private Text text;

	// Use this for initialization
	public void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void Update () {
        text.text = "Life: " + Player.player.life;
	}
}
