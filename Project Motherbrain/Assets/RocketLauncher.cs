using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public Transform Target;
    public bool ShouldLaunch;

    [SerializeField] private Transform Silo1;
    [SerializeField] private Transform Silo2;
    [SerializeField] private Transform Silo3;

    [SerializeField] private GameObject RocketPrefab;
    [SerializeField] private float LaunchDelay = 0.5f;

    private float _launchTimer;
    private int _rocketIndex = 1;
    private bool _mustLaunch;

    private void Update()
    {
        if (ShouldLaunch)
        {
            _mustLaunch = true;
            ShouldLaunch = false;
        }

        if (_launchTimer > 0)
        {
            _launchTimer -= Time.deltaTime;
            return;
        }

        if (!_mustLaunch)
            return;

        SpawnRocket();
    }

    private void SpawnRocket()
    {
        if (_rocketIndex > 3)
        {
            _rocketIndex = 1;
            _mustLaunch = false;
        }

        Transform silo = _rocketIndex == 1 ? Silo1 : (_rocketIndex == 2 ? Silo2 : Silo3);

        Rocket rocket = Instantiate(RocketPrefab, silo.position, silo.rotation).GetComponent<Rocket>();
        rocket.SetTarget(Target);
        _rocketIndex++;
        _launchTimer = LaunchDelay;
    }

    public void Launch()
    {
        _mustLaunch = true;
        SpawnRocket();
    }
}