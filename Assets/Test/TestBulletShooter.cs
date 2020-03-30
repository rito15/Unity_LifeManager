using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rito;

public enum TestMode
{
    Default,
    UseSlowDestruction,
    UseObjectPool
}

public class TestBulletShooter : MonoBehaviour
{
    public GameObject _bulletPrefab;

    [Space]
    public int _bulletNumberAtOnce = 10;
    public float _shootingFrequency = 0.3f;
    public float _lifeCycleSeconds = 3f;
    public float _speed = 5f;

    [Space]
    public TestMode _testMode = TestMode.Default;
    public bool _isRunning = false;

    private LifeManager _lm;

    private void Awake()
    {
        _lm = LifeManager.I;
    }

    private void Start()
    {
        StartCoroutine(TestRoutine());
    }

    /// <summary>
    /// <para/> 코루틴 : 
    /// <para/> 
    /// </summary>
    private IEnumerator TestRoutine()
    {
        yield return new WaitForEndOfFrame();

        /* Thread */
        while (true)
        {
            yield return new WaitForSeconds(_shootingFrequency);

            if (_isRunning == false) continue;
            if (_bulletPrefab == null) continue;

            for(int i = 0; i < _bulletNumberAtOnce; i++)
            {
                GameObject bullet;

                switch(_testMode)
                {
                    case TestMode.Default:
                    default:
                        bullet = Instantiate(_bulletPrefab, transform.position, default);
                        GameObject.Destroy(bullet, _lifeCycleSeconds);
                        break;

                    case TestMode.UseSlowDestruction:
                        bullet = Instantiate(_bulletPrefab, transform.position, default);
                        LifeManager.I.Destroy_(bullet, _lifeCycleSeconds);
                        break;

                    case TestMode.UseObjectPool:
                        bullet = _lm.Instantiate(_bulletPrefab, transform.position);
                        LifeManager.I.Save(bullet, _lifeCycleSeconds);
                        break;
                }

                float vecX = Random.Range(-1f, 1f);
                float vecZ = Random.Range(-1f, 1f);
                Vector3 dir = new Vector3(vecX, 0f, vecZ).normalized;

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = bullet.AddComponent<Rigidbody>();

                rb.useGravity = false;

                rb.AddForce(dir * _speed, ForceMode.Acceleration);
            }
        }
    }
}
