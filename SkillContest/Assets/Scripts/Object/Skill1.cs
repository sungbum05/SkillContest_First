using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    static Skill1 instance;

    public float BombSpeed;

    public static void Skiil1Effect()
    {
        while (true)
        {
            instance.gameObject.transform.localScale += Vector3.one * instance.BombSpeed * Time.deltaTime;

            
                
        }
    }
}
