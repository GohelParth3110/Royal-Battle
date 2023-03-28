using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject obj_Player;
    public  GameObject Player { get; private set; }

    private void Awake() {
        instance = this;
    }
    private void Start() {
        GameObject player = Instantiate(obj_Player, transform.position, transform.rotation);
        this.Player = player;
    }

  
}
