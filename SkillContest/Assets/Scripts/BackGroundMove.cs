using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BackImgInfo
{
    public Image Resource;
    public RectTransform RectTransform;

    public Vector2 Size;

    public RectTransform ChasingObj;
    public int BorderValue;
}

public class BackGroundMove : MonoBehaviour
{
    public List<BackImgInfo> backImgInfos = new List<BackImgInfo>();

    public float ScrollingSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        for (int i = 0; i < backImgInfos.Count; i++)
        {
            backImgInfos[i].Resource.gameObject.transform.Translate(Vector2.down * ScrollingSpeed * Time.deltaTime);

            if (backImgInfos[i].RectTransform.anchoredPosition.y <= backImgInfos[i].BorderValue)
                backImgInfos[i].RectTransform.anchoredPosition = backImgInfos[i].ChasingObj.anchoredPosition + new Vector2(0, backImgInfos[i].Size.y - 5);
        }
    }
}
