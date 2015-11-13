using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class WanderAI : MonoBehaviour {

    public GameObject[] wanderPoints;
    public GameObject player;

    public GameObject roboMesh;

    private float seenByTime = 0f;
    private AICharacterControl aiCharControl;

    // Use this for initialization
    void Start () {

        aiCharControl = GetComponent<AICharacterControl>(); 
        aiCharControl.target = (wanderPoints[Random.Range(0, wanderPoints.Length)].transform.position);    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        Vector3 direction = (playerPos - transform.position).normalized;
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.red);
        roboMesh.GetComponent<SkinnedMeshRenderer>().enabled = true;
        if (Physics.Raycast(transform.position, direction, out hit, float.MaxValue, 1<<8 | 1<<9))
        {
            if(hit.transform == player.transform)
            {
                seenByTime += Time.deltaTime;
                aiCharControl.SetTarget(player.transform.position);
            }
            else
            {
                seenByTime = 0f;
                roboMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
                if (Vector3.Distance(aiCharControl.target, transform.position) < 1.5f)
                    aiCharControl.SetTarget(wanderPoints[Random.Range(0, wanderPoints.Length)].transform.position);
            }
        }
        else if (Vector3.Distance(aiCharControl.target, transform.position) < 3f)
            aiCharControl.SetTarget(wanderPoints[Random.Range(0, wanderPoints.Length)].transform.position);

        if (seenByTime > 3)
            player.GetComponent<Player>().GameOver();
	}
}
