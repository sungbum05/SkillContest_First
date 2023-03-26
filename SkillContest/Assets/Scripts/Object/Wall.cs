using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float ScrollingSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        this.transform.Translate(Vector3.back * ScrollingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyZone"))
        {
            MapMakeManager.ReturnObject(this.gameObject);
        }
    }
}
