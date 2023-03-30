using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private GameObject[] all_Powerup;
    [SerializeField] private Level[] all_Level;
    [SerializeField] private int currentLevelNO;
    [SerializeField] private Level CurrentLevel;
    [SerializeField] private float currentEnemyCount;
    [SerializeField] private float flt_CurrentTime;
    public float flt_BoundryX;
    public float flt_BoundryZ;
    public float flt_Boundry;
    [SerializeField] private GameObject grass;
    [SerializeField] private Transform ground;
    [SerializeField]private int postionX;
    [SerializeField]private int postionZ;
    private bool isSpawnGrass;
    private bool isFirstTime = true;

    private void Awake() {
        instance = this;
    }
    public void StartGame() {
        isFirstTime = true;
        currentLevelNO = 0;
        CurrentLevel = all_Level[currentLevelNO];
        StartCoroutine(SpawnGrass());
    }
    private void Update() {
        if (!GameManager.instance.isPlayerLive) {
            return;
        }
        if (isSpawnGrass) {
            return;
        }
        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime>CurrentLevel.flt_SpawnEnemyTime) {
            SpawnEnemy();
            flt_CurrentTime = 0;
        }
       
    }
    private IEnumerator SpawnGrass() {

        isSpawnGrass = true;
        for (int i = Mathf.Abs(postionX/8); i <= currentLevelNO; i++) {
            postionZ = 0;
            for (int j = Mathf.Abs(postionZ / 8); j <= currentLevelNO; j++) {
            
               GameObject current =   Instantiate(grass, new Vector3(postionX,15,postionZ), transform.rotation, ground);

                current.transform.DOMoveY(0, 0.5f);
                yield return new WaitForSeconds(0.5f);
               
                postionZ -= 8;
            }
            postionX -= 8;
        }

        int x = postionX+8;
      
        for (int i = Mathf.Abs(x / 8); i >=0; i--) {

           
            GameObject current =   Instantiate(grass, new Vector3(x, 15, postionZ), transform.rotation, ground);
            current.transform.DOMoveY(0, 0.5f);
            yield return new WaitForSeconds(0.5f);
            x += 8;
        }

        if (isFirstTime) {
            PlayerManager.instance.SpawnPLayer();
            isFirstTime = false;
        }
        isSpawnGrass = false;

    }

   

    private void SpawnEnemy() {
        while (currentEnemyCount<CurrentLevel.noofSpwnEnemy) {
            int index = Random.Range(0, CurrentLevel.all_EnemySpawn.Length);
            
            Instantiate(CurrentLevel.all_EnemySpawn[index],new Vector3(Random.Range(flt_Boundry,flt_BoundryX),0.5f,
                Random.Range(flt_Boundry, flt_BoundryZ)), transform.rotation);

            currentEnemyCount++;
            return;
        }
        currentEnemyCount = 0;
        currentLevelNO++;
        CurrentLevel = all_Level[currentLevelNO];
        flt_BoundryX -= 8;
        flt_BoundryZ -= 8;
        StartCoroutine(SpawnGrass());
    }
}

[System.Serializable]
public struct Level {

    public  int noofSpwnEnemy;
    public GameObject[] all_EnemySpawn;
    public float flt_SpawnEnemyTime;

}
