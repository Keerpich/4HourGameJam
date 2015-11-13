using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //WaitAndLoad();
	}

    void Update()
    {
        if (Input.anyKey)
            Application.LoadLevel("Game");
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(4f);
        Application.LoadLevel("Game");
    }

}
