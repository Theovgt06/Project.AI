using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private DimensionManager dimension;
    internal void Debug1press() {
        dimension.SetAlpha(0, 1);
        StartCoroutine(dimension.SetCollision(false, 1));
    }

    internal void Debug1release() {
        dimension.SetAlpha(0.5f, 1);
        StartCoroutine(dimension.SetCollision(true, 1));
    }

    internal void Debug2press() {

    }

    internal void Debug2release() {

    }


    
}
