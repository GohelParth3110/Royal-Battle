using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] all_Powerup;
    [SerializeField] private Level[] all_Level;
    [SerializeField] private int currentLevelNO;
    [SerializeField] private Level CurrentLevel;
    [SerializeField] private float currentEnemyCount;
    [SerializeField] private float flt_CurrentTime;
    [SerializeField] private float flt_Boundry;
    [SerializeField] private GameObject grass;
    private int postionX;
    private int postionZ;

    private void Start() {
        currentLevelNO = 0;
        CurrentLevel = all_Level[currentLevelNO];
        SpawnGrass();
    }
    private void Update() {

        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime>CurrentLevel.flt_SpawnEnemyTime) {
            SpawnEnemy();
            flt_CurrentTime = 0;
        }
       
    }
    private void SpawnGrass() {
        postionX = 0;
        postionZ = 0;
        for (int i = 0; i <= currentLevelNO; i++) {
            postionZ = 0;
            for (int j = 0; j <= currentLevelNO; j++) {
                 
                
                 Instantiate(grass, new Vector3(postionX,0,postionZ), transform.rotation);
                postionZ += 8;
            }
            postionX += 8;
        }
    }
    private void SpawnEnemy() {
        while (currentEnemyCount<CurrentLevel.noofSpwnEnemy) {
            int index = Random.Range(0, CurrentLevel.all_EnemySpawn.Length);
            
            Instantiate(CurrentLevel.all_EnemySpawn[index],new Vector3(Random.Range(-3.5f,flt_Boundry),0,
                Random.Range(-3.5f, flt_Boundry)), transform.rotation);

            currentEnemyCount++;
            return;
        }
        currentEnemyCount = 0;
        currentLevelNO++;
        CurrentLevel = all_Level[currentLevelNO];
        SpawnGrass();
    }
}

[System.Serializable]
public struct Level {

    public  int noofSpwnEnemy;
    public GameObject[] all_EnemySpawn;
    public float flt_SpawnEnemyTime;

}
