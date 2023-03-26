using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakeManager : MonoBehaviour
{
    public Transform SpawnPos;
    public List<Transform> SpawnPosList;

    public int MaxLeft, MaxRight;
    public int Left, Right;

    private void Awake()
    {
        BasicSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BasicSetting()
    {
        foreach (Transform Pos in SpawnPos)
        {
            SpawnPosList.Add(Pos);
        }
    }
}
