using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rito;

public class LifeManagerTester : MonoBehaviour
{
    public GameObject m_testObject1;
    public GameObject m_testObject2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && m_testObject1)
        {
            float x = Random.Range(-10f, 0f);
            float y = Random.Range(-10f, 0f);
            float z = Random.Range(-10f, 0f);

            var @new = LifeManager.I.Instantiate(m_testObject1, new Vector3(x, y, z));
            LifeManager.I.Save(@new, 3f);
        }

        if(Input.GetKey(KeyCode.S) && m_testObject2)
        {
            float x = Random.Range(0f, 10f);
            float y = Random.Range(0f, 10f);
            float z = Random.Range(0f, 10f);

            var @new = LifeManager.I.Instantiate(m_testObject2, new Vector3(x, y, z));
            LifeManager.I.Save(@new, 3f);
        }
    }
}
