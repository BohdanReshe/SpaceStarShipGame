using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTextAnimationScript : MonoBehaviour
{
    [Header("Approximate Scale")]
    [SerializeField] float _scaleVar;
    [SerializeField] float _speedAnimation;
    [SerializeField] float _minScale;
    [SerializeField] float _maxScale;



    void Update()
    {
        transform.localScale = new Vector3(_scaleVar, _scaleVar, _scaleVar);
        _scaleVar += _speedAnimation * Time.deltaTime;
        if (_scaleVar < _minScale)
        {
            _speedAnimation = -_speedAnimation;
        }
        if (_scaleVar > _maxScale)
        {
            _speedAnimation = -_speedAnimation;
        }
    }
}
