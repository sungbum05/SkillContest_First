using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("MoveBorder")]
    public float MoveSpeed;

    public Vector2 BorderX;
    public Vector2 BorderZ;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        this.transform.Translate(new Vector3(Horizontal, 0, Vertical) * MoveSpeed * Time.deltaTime);
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, BorderX.y, BorderX.x), this.transform.position.y, Mathf.Clamp(transform.position.z, BorderZ.y, BorderZ.x));
    }

}
