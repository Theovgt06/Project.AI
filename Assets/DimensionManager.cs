using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] private Tilemap[] tilemaps;
    [SerializeField] private GameObject otherObjectsParent;

    public void setAlpha(float newAlpha, float timeLength = 0f) {
        for (int i=0; i<tilemaps.Length; i++) {
            var tilemapAlpha = tilemaps[i].color.a;
            DOTween.To(()=> tilemapAlpha, x=> tilemapAlpha = x, newAlpha, timeLength);
        }

        throw new NotImplementedException();
    }

    public void setCollision(bool active, float delay = 0f) {
        throw new NotImplementedException();
    }
}
