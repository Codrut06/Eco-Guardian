using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().DamageEnemy(damage);
            Destroy(gameObject);
        }
    }
}

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject projectilePrefab;
    public Transform shotPoint;
    public float startTinmeBtwShots;
    private float timeBtwShots;
    private GameObject player;
    public bool canShoot = true;
    private bool gunFacingRight;
    private bool gunFacingLeft;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                Shoot();
                timeBtwShots = startTinmeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shotPoint.position, transform.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.damage = 10; // Set the damage value as desired

        // Add a trail renderer to the projectile
        TrailRenderer trail = projectile.AddComponent<TrailRenderer>();
        trail.startWidth = 0.1f;
        trail.endWidth = 0.05f;
        trail.time = 3f;
        trail.material = spriteRenderer.material;

        // Apply force to the projectile in the direction it is fired
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(projectile.transform.right * 500f);

        // Ignore collisions between the projectile and the player
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
}
