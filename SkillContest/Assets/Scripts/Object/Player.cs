using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("MoveBorder")]
    public float MoveSpeed;

    public Vector2 BorderX;
    public Vector2 BorderZ;

    [Header("Attack - Rotation")]
    public GameObject Gun;

    public float RotationSpeed;
    public float CurRot;
    public float MaxRot, MinRot;

    [Header("Attack - Fire")]
    public GameObject BulletPrefab;
    public float BulletForce;

    public float MaxAttackDelay;
    public float CurAttackDelay;

    public Transform BulletSpawnPos;

    // Update is called once per frame
    void Update()
    {
        Move();
        GunRotation();
    }

    void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        this.transform.Translate(new Vector3(Horizontal, 0, Vertical) * MoveSpeed * Time.deltaTime);
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, BorderX.y, BorderX.x), 
            this.transform.position.y, Mathf.Clamp(transform.position.z, BorderZ.y, BorderZ.x));
    }

    void GunRotation()
    {
        if (CurAttackDelay > 0)
            CurAttackDelay -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            CurRot = 0;

            if (CurAttackDelay <= 0)
                Fire();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CurRot = -1;

            if (CurAttackDelay <= 0)
                Fire();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            CurRot = 1;

            if (CurAttackDelay <= 0)
                Fire();
        }
        else
            CurRot = 0;

        Gun.transform.Rotate(Vector3.up * CurRot * RotationSpeed * Time.deltaTime);
    }

    void Fire()
    {
        CurAttackDelay += MaxAttackDelay;

        GameObject Bullet = Instantiate(BulletPrefab);
        Bullet.transform.position = BulletSpawnPos.position;

        Bullet.GetComponent<Rigidbody>().AddForce(Gun.transform.forward * BulletForce, ForceMode.Impulse);
    }
}
