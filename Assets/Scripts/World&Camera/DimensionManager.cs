using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] private Tilemap[] tilemaps;
    [SerializeField] private GameObject otherObjectsParent;

    //Anime la transparence de chaque tilemap avec DOTween
    public void SetAlpha(float newAlpha, float timeLength = 0f) {
        foreach (Tilemap tilemap in tilemaps) {
            DOTween.To(()=> tilemap.color.a,
                x=> {var color = tilemap.color; color.a = x; tilemap.color = color;},
                newAlpha,
                timeLength);
        }
    }

    //active ou désactive les collisions après un délai donné
    //⚠️ A n'appeler qu'avec un StartCoroutine()
    public IEnumerator SetCollision(bool active, float delay = 0f) {
        yield return new WaitForSeconds(delay);
        foreach (Tilemap tilemap in tilemaps) {
            TilemapCollider2D collider = tilemap.GetComponent<TilemapCollider2D>();
            if (collider != null) {
                collider.enabled = active;
                print(collider.name + active);
            }
        }
    }
}
