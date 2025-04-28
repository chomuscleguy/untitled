using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackSpeed = 10f;
    public float delay = 1f;
    public float minDelay = 0.1f;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delay *= 0.9f;
            Debug.Log(delay);
        }
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            FireBullet();
            Debug.Log(delay);
            yield return new WaitForSeconds(delay);
        }
    }

    private void FireBullet()
    {
        GameObject missile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();

        Vector2 direction = Vector2.up;
        rb.linearVelocity = direction * attackSpeed;
    }
}
