using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //clasa cu viata player-ului
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }

        }
        public void Inint()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        stats.Inint();
        if(statusIndicator == null)
        {
            Debug.LogError("eroare");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);  //setez bara de viata a player-ului
        }
    }


    //player-ul ia damage
    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        if(stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);  //daca inca mai traieste setez bara de viata dupa ce si-a luat damage 
    }
}
