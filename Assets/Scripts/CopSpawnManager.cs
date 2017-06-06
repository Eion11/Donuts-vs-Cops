using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CopSpawnManager : MonoBehaviour
{
    public Object copStandard, copFast, copTank;        // Cop Prefabs

    public int startingNumberOfCopsInWave, waveMax, copWaveModiferInbetweenWaves;
    private int randomLane, randomCop;
    private int amountOfCopsInLevel;
    private int waveCount;

    public float startWait, waveWait, spawnWait;

    private GameObject winCondition;
    private GameObject[] lanes, cops;
    private Object[] copSpawnChance = new Object[100];
    private float[] lanePositions = new float[5];

    void Start()
    {
        winCondition = GameObject.Find("WinCondition");
        amountOfCopsInLevel = startingNumberOfCopsInWave * waveMax + ((waveMax) * copWaveModiferInbetweenWaves);
        winCondition.GetComponent<WinCondition>().setCopKillVictory(amountOfCopsInLevel);
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {
        lanes = GameObject.FindGameObjectsWithTag("Lane");
        for (int i = 0; i < lanes.Length; i++)
        {
            lanePositions[i] = lanes[i].GetComponent<LanePosition>().laneYPosition;
        }

        for (int i = 0; i < 60; i++)
        {
            copSpawnChance[i] = copStandard;
        }
        for (int i = 60; i < 80; i++)
        {
            copSpawnChance[i] = copFast;

        }
        for (int i = 80; i < 100; i++)
        {
            copSpawnChance[i] = copTank;

        }

        bool isSpawning = true;

        yield return new WaitForSeconds(startWait);
        while (isSpawning)
        {
            for (int i = 0; i < startingNumberOfCopsInWave; i++)
            {
                randomLane = Random.Range(0, lanes.Length);
                randomCop = Random.Range(0, 99);

                Vector3 spawnPosition = new Vector3(8, lanePositions[randomLane], 0); //2.35f Top lane
                GameObject copToSpawn = copSpawnChance[randomCop] as GameObject;
                GameObject cop = Instantiate(copToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                cop.GetComponent<LanePlacement>().lane = lanes[randomLane];

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            waveCount++;
            startingNumberOfCopsInWave += copWaveModiferInbetweenWaves;
            spawnWait *= 0.75f;

            if (waveCount == waveMax)
            {
                isSpawning = false;
                Debug.Log(amountOfCopsInLevel);
            }
        }
    }
}