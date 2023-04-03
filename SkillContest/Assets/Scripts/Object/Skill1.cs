using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    [Header("Attack - Skill")]
    public KeyCode UseSkillKey1;
    public KeyCode UseSkillKey2;

    public GameObject BazierBulletPrefab;

    public float BulletSpeed;
    public float ScPow;
    public float ThiPow;

    public GameObject Target;

    private void Update()
    {
        if(Input.GetKey(UseSkillKey1))
        {
            GameObject BazierBullet = Instantiate(BazierBulletPrefab);

            BazierBullet.GetComponent<BazierBullet>().Init(this.transform, Target.transform, BulletSpeed, ScPow, ThiPow);
        }
    }
}
