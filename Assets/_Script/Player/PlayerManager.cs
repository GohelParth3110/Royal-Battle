using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject obj_Player;
    [SerializeField] private CinemachineVirtualCamera Camera_Virtual;
    public  GameObject Player { get; private set; }

    private void Awake() {
        instance = this;
    }
    public void SpawnPLayer() {
        GameObject player = Instantiate(obj_Player, transform.position, transform.rotation);
        this.Player = player;
        Camera_Virtual.Follow = this.Player.transform;
        GameManager.instance.isPlayerLive = true;
      
    }

  
}
