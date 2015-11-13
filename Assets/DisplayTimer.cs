using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayTimer : MonoBehaviour {

    public float time = 0f;
    Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        txt.text = ((int)time).ToString();
	}
}
