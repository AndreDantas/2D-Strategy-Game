﻿using UnityEngine;
using Sirenix.OdinInspector;
public class BaseMap
{

    [SerializeField, HideInInspector] private int _width;
    [SerializeField, HideInInspector] private int _height;

    /// <summary>
    /// Map's width.
    /// </summary>
    [ShowInInspector] public int width { get => _width; set => _width = Mathf.Max(value, 0); }
    /// <summary>
    /// Map's height.
    /// </summary>
    [ShowInInspector] public int height { get => _height; set => _height = Mathf.Max(value, 0); }

    public BaseMap()
    {
    }

    public BaseMap(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

}