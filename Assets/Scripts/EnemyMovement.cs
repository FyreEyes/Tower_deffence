using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        target = Waypoints.wayPoints[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        _enemy.speed = _enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }
        
        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
