using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawn = 7f;
    [SerializeField]
    private float current_Timer = 0f;

    public GameObject enemyFighter;
    public Transform spawnPosition;

    private void Update()
    {
        current_Timer += Time.deltaTime;

        if(current_Timer>timeToSpawn)
        {
            Instantiate(enemyFighter, spawnPosition.position+new Vector3(Random.Range(-21,26),0), Quaternion.identity);
            current_Timer = 0;
        }
    }

}
