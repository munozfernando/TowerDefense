using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;
    private Transform _target;
    private int _pointIndex = 0;

    public void Start()
    {
        _target = Waypoints.waypoints[0];
    }

    public float Speed
    {
        get { return _speed;}
        set {_speed = value; }
    }
    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, _target.position) <= .5f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(_pointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(this);
            return;
        }
        _pointIndex++;
        _target = Waypoints.waypoints[_pointIndex];
    }
}
