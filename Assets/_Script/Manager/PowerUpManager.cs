using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instnce;
    [SerializeField] private GameObject[] all_PowerUp;
    private float flt_Yoffset = 1;

    private void Awake() {
        instnce = this;
    }
    public  void SpawnPowerUp() {
        int index = Random.Range(0, all_PowerUp.Length);
        Vector3 Postion = new Vector3(Random.Range(LevelManager.instance.flt_Boundry, 
            LevelManager.instance.flt_BoundryX), flt_Yoffset, Random.Range(LevelManager.instance.flt_Boundry
           , LevelManager.instance.flt_BoundryZ));

        Instantiate(all_PowerUp[index], Postion, transform.rotation);

            
    }
}
