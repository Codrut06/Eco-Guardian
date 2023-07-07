using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] itemDrops;

    //clasa cu stats pentru inamic
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }  
        }

        public int damage = 20;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }
    public EnemyStats stats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;  //bara de viata

    void Start()
    {
        stats.Init();

        if(statusIndicator != null) 
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);  //seteaza bara de viata in functie de cata viata mai are
        }
    }
    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;  //isi ia damage enemy-ul
        if(stats.curHealth <= 0) 
        {
            GameMaster.KillEnemy(this);
            ItemDrop();
        }
        if (stats.curHealth != 0)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);  //setez bara de viata daca inca mai traieste inamicul
        }
    }
    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        }
    }

    void OnCollisionEnter2D(Collision2D _colinfo)
    {
        PlayerHealth _player = _colinfo.collider.GetComponent<PlayerHealth>();  //daca inamicul se loveste de player
        if(_player != null) 
        {
            _player.DamagePlayer(stats.damage);  //player-ul isi ia damage
        }
    }
}
