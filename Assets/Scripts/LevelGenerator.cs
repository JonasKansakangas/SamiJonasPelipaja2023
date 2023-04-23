using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    #region Members
    public bool DebugMode = false;
    public List<GameObject> LevelPrefabs = new List<GameObject>();
    float _offset = -20;
    private float _cameraLeftCorner;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Get the left corner of camera (Level objects are instantiated here)
        _cameraLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)).y;

        //Generate 10 "real" pieces
        for (int i = 0; i < 20; i++)
        {
            InstantiateNewLevelObject(i < 6 ? 0 : (int?)null);
        }

    }

    //Get the bounds of the level prefab (so we can have different sized level objects and they still work)
    Bounds GetMaxBounds(GameObject g)
    {
        var renderers = g.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return new Bounds(g.transform.position, Vector3.zero);
        var b = renderers[0].bounds;
        foreach (Renderer r in renderers)
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }

    /// <summary>
    /// Level generator hit a level prefab, delete it and generate a new one
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject.transform.parent.gameObject);
        InstantiateNewLevelObject();
    }

    /// <summary>
    /// Instantiate a level prefab at the correct position
    /// </summary>
    private void InstantiateNewLevelObject(int? index = null)
    {
        GameObject go = LevelPrefabs[DebugMode ? 0 : index.HasValue ? index.Value : Random.Range(0, LevelPrefabs.Count)];
        GameObject.Instantiate(go, new Vector3(_offset, _cameraLeftCorner-0.32f, 0), Quaternion.identity);
        _offset += GetMaxBounds(go).size.x;
    }

    
}
