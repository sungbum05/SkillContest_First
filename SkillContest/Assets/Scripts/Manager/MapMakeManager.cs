using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakeManager : MonoBehaviour
{
    public static MapMakeManager instance;

    [Header("SpawnInfo")]
    public Transform SpawnPos;
    public List<Transform> SpawnPosList;

    public int MaxLeft, MaxRight;
    public int Left, Right;

    public float SpawnDelay;

    [Header("ObjectPool")]
    public GameObject AstroPrefab;
    public Queue<GameObject> ObjectPool = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        BasicSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BasicSetting()
    {
        Initialized(10);

        foreach (Transform Pos in SpawnPos)
        {
            SpawnPosList.Add(Pos);
        }

        StartCoroutine(WallSpawn());
    }

    IEnumerator WallSpawn()
    {
        while (true)
        {
            yield return null;
            int MoveValue = 0;

            if (Right >= MaxRight)
            {
                MoveValue = Random.Range(-1, 1);
            }

            else if (Left <= MaxLeft)
            {
                MoveValue = Random.Range(0, 2);
            }

            else
            {
                MoveValue = Random.Range(-1, 2);
            }

            Right += MoveValue;
            Left += MoveValue;

            RightWallSpawn(Right);
            LeftWallSpawn(Left);

            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    public void RightWallSpawn(int Right)
    {
        GameObject NewWall = GetObject();

        NewWall.transform.position = SpawnPosList[this.Right].position;
    }

    public void LeftWallSpawn(int Left)
    {
        GameObject NewWall = GetObject();

        NewWall.transform.position = SpawnPosList[this.Left].position;
    }

    #region ObjectPool
    private void Initialized(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            ObjectPool.Enqueue(CreatNewObject());
        }
    }

    private GameObject CreatNewObject()
    {
        GameObject PoolObj = Instantiate(AstroPrefab);

        PoolObj.transform.SetParent(this.transform);
        PoolObj.SetActive(false);

        return PoolObj;
    }

    private GameObject GetObject()
    {
        if (ObjectPool.Count > 0)
        {
            GameObject GetObj = ObjectPool.Dequeue();

            GetObj.transform.SetParent(null);
            GetObj.SetActive(true);

            return GetObj;
        }

        else
        {
            GameObject GetObj = CreatNewObject();

            GetObj.transform.SetParent(null);
            GetObj.SetActive(true);

            return GetObj;
        }
    }

    public static void ReturnObject(GameObject ReturnObj)
    {
        ReturnObj.transform.SetParent(instance.transform);
        ReturnObj.SetActive(false);

        instance.ObjectPool.Enqueue(ReturnObj);
    }
    #endregion

}
