using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power;

    public string color;

    private void Start()
    {
        Destroy(gameObject, 7);
    }

    public void BulletMovement(GameObject firePoint)
    {
        GetComponent<Rigidbody2D>().AddForce(firePoint.transform.forward * power);
    }
}
