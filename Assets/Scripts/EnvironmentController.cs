using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private DimensionManager dimension;
    internal void Debug1press()
    {
        DOTween.To(()=> tilemap.color, x=> tilemap.color = x, new Color(1,1,1,0), 1);
        // throw new NotImplementedException();
    }

    internal void Debug1release()
    {
        DOTween.To(()=> tilemap.color, x=> tilemap.color = x, new Color(1,1,1,1), 1);
        // throw new NotImplementedException();
    }

    internal void Debug2press()
    {
        dimension.setAlpha(0, 1);
        // throw new NotImplementedException();
    }

    internal void Debug2release()
    {
        dimension.setAlpha(0.5f, 1);
        // throw new NotImplementedException();
    }


    
}
