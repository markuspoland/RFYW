using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float timer;
    public enum EnemySide { Right, Left }

    public EnemySide enemySide;

    private void OnEnable()
    {
        timer = 1f;
    }
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 2.5f * Time.deltaTime;

        if (timer > 0f)
        {
            if (enemySide == EnemySide.Left)
            {
                transform.Translate(-Vector3.right * 3f * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * 3f * Time.deltaTime);
            }
        }
    }

}
