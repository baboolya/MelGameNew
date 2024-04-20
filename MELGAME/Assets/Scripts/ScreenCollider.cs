using System;
using System.Collections.Generic;
using Source.Scripts.Objects;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ScreenCollider2D : MonoBehaviour
{
    private EdgeCollider2D _collider;
    private Camera _camera;

    private float _currentWidth;
    private float _currentHeight;

    private void Start()
    {
        _collider = GetComponent<EdgeCollider2D>();
        _camera = Camera.main;

        GenerateCollider();
    }

    private void Update()
    {
        if(_currentHeight != UnityEngine.Screen.height || _currentWidth != UnityEngine.Screen.width)
        {
            GenerateCollider();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collisionObject = collision.transform.GetComponent<Rigidbody2D>();
        Target target = collision.transform.GetComponent<Target>();
        Vector3 reflectedDirection = Vector3.Reflect(target.Velocity, -collision.contacts[0].normal);
        collisionObject.velocity = reflectedDirection;
    }

    private void GenerateCollider()
    {
        List<Vector2> edges = new();

        edges.Add(_camera.ScreenToWorldPoint(Vector2.zero));

        edges.Add(_camera.ScreenToWorldPoint(new Vector2(UnityEngine.Screen.width, 0)));
        edges.Add(_camera.ScreenToWorldPoint(new Vector2(UnityEngine.Screen.width, UnityEngine.Screen.height)));
        edges.Add(_camera.ScreenToWorldPoint(new Vector2(0, UnityEngine.Screen.height)));

        edges.Add(_camera.ScreenToWorldPoint(Vector2.zero));
        _collider.SetPoints(edges);

        _currentHeight = UnityEngine.Screen.height;
        _currentWidth = UnityEngine.Screen.width;
    }
}