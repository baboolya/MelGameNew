using System;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Source.Scripts.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]

    public class Target : MonoBehaviour
    {
        [SerializeField] private float _throwForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _acceleration;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _image;

        private Vector3 _throwVector;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _velocity;
        private bool _isPlayed = true;

        private int _value;
        private string _suit;
        private Sprite _sprite;

        public Vector3 Velocity => _velocity;

        public Target(int value, string suit, Sprite sprite)
        {
            _value = value;
            _suit = suit;

            _sprite = sprite;
        }

        private Camera _mainCamera;
 
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _sprite = _image.sprite;

            CalculateRandomVector();
            Throw(_throwVector);
        }

        private void Update()
        {
            Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);

            if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
            {
                RespawnOnBoard();
            }

            _velocity = new Vector3(2f, 2f, 2f);
        }

        private void CalculateRandomVector()
        {
            _throwVector = Random.insideUnitCircle.normalized;
        }

        public void Respawn()
        {
            CalculateRandomVector();
            Throw(_throwVector);
        }

        public void Throw(Vector3 direction)
        {
            _speed = 1.8f;
            _rigidbody2D.velocity = direction * _throwForce * _speed;
        }

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public void ConfirmSprite()
        {
            _image.sprite = _sprite;
        }

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
            _image.sprite = sprite;
        }

        public void SetValue(int value)
        {
            _value = value;
        }

        public void SetSuit(string key)
        {
            _suit = key;
        }

        public void SetCanvas(Canvas canvas)
        {
            _canvas = canvas;
        }

        public int GetValue()
        {
            return _value;
        }

        public string GetSuit()
        {
            return _suit;
        }

        private void RespawnOnBoard()
        {
            Vector3 centerScreen = new Vector3(0.5f, 0.5f, _mainCamera.nearClipPlane + 1); 
            transform.position = _mainCamera.ViewportToWorldPoint(centerScreen);
        }
    }
}
