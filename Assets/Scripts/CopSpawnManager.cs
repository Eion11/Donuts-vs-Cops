using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CopSpawnManager : MonoBehaviour
{

    public Object Cop_Standard, Cop_Fast, Cop_Tank;
    public Vector3 spawnValues;
    public float Lane1, Lane2, Lane3, Lane4, Lane5;
    public int copCount;
    public float spawnWait, startWait, waveWait;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {
        Debug.Log("I was hit");
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < copCount; i++)
            {
                Vector3 spawnPosition = new Vector3(8, Random.Range(Lane1, Lane5), 0); //2.35f Top lane
                Instantiate(Cop_Standard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

    //    IEnumerator spawnWaves()
    //    {
    //        yield return new WaitForSeconds(startWait);
    //        while(true)
    //        {
    //            for(int i = 0; i < copCount; i++)
    //            {
    //                switch()
    //            }
    //        }
    //    }
    //}

}
