using UnityEngine;
using System.Collections;

public class SeekerSpawner : MonoBehaviour {

    [SerializeField]
    GameObject seekerPrefab;

    [SerializeField]
    int spawnTimeInSeconds = 60;

    [SerializeField]
    GameObject[] wanderPoints;

    [SerializeField]
    GameObject player;

    [SerializeField]
    AudioSource audio;
    [SerializeField]
    AudioClip enemySpawnSound;

    float timeSinceSpawn = 0f;


	// Use this for initialization
	void Start () {
        if (seekerPrefab == null)
        {
            throw new System.Exception("No Seeker Prefab attached");
        }

        audio.PlayOneShot(enemySpawnSound);

        timeSinceSpawn = 0f;
        GameObject seeker = Instantiate(seekerPrefab, transform.position, Quaternion.identity) as GameObject;
        seeker.GetComponent<WanderAI>().wanderPoints = wanderPoints;
        seeker.GetComponent<WanderAI>().player = player;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn > spawnTimeInSeconds)
        {
            timeSinceSpawn = 0f;
            audio.PlayOneShot(enemySpawnSound);
            GameObject seeker = Instantiate(seekerPrefab, transform.position, Quaternion.identity) as GameObject;
            seeker.GetComponent<WanderAI>().wanderPoints = wanderPoints;
            seeker.GetComponent<WanderAI>().player = player;
        }

	}
}
