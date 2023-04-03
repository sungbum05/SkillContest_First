using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazierBullet : MonoBehaviour
{
    public bool IsTarget = false;

    public Vector3[] Points = new Vector3[4];

    public float MaxTime;
    public float CurTime;
    public float Speed;

    public void Init(Transform StartPoint, Transform EndPoint, float BulletSpeed, float ScPow, float ThiPow)
    {
        Speed = BulletSpeed;
        MaxTime = Random.Range(0.8f, 1.0f);

        Points[0] = StartPoint.position;

        Points[1] = StartPoint.position
            + (ScPow * Random.Range(-1.0f, 1.0f) * StartPoint.right)
            + (ScPow * Random.Range(-1.0f, 1.0f) * StartPoint.up)
            + (ScPow * Random.Range(-1.0f, -0.8f) * StartPoint.forward);

        Points[2] = EndPoint.position
            + (ThiPow * Random.Range(-1.0f, 1.0f) * EndPoint.right)
            + (ThiPow * Random.Range(-1.0f, 1.0f) * EndPoint.up)
            + (ThiPow * Random.Range(0.8f, 1.0f) * EndPoint.forward);

        Points[3] = EndPoint.position;

        transform.position = StartPoint.position;
        IsTarget = true;
    }

    public void Update()
    {
        if(IsTarget && CurTime <= MaxTime)
        {
            CurTime += Time.deltaTime * Speed;
            transform.position = BazierMove(Points[0], Points[1], Points[2], Points[3]);
        }

        else
        {
            Debug.Log("Done");
        }
    }

    public Vector3 BazierMove(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        float t = CurTime / MaxTime;

        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        Vector3 cd = Vector3.Lerp(c, d, t);

        Vector3 abbc = Vector3.Lerp(ab, bc, t);
        Vector3 bccd = Vector3.Lerp(bc, cd, t);

        return Vector3.Lerp(abbc, bccd, t);
    }
}
