using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public UnityEngine.UI.Text canvasText;
    public DisplayTimer displayTimer;

    public void GameOver()
    {
        displayTimer.gameObject.SetActive(false);
        canvasText.gameObject.SetActive(true);
        canvasText.text = "Game Over!\nYour Score: " + (int)(displayTimer.time);
        StartCoroutine(WaitAndRestart());
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Intro");
    }

}
