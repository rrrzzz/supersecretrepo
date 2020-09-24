using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class PlanePlacer : MonoBehaviour
{
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [MenuItem("MyTools/CreateGameObjects")]
    void Create()
    {
        for (int x=0; x!=10; x++)
        {
            GameObject go = new GameObject($"MyCreatedGO{i++}");
            go.transform.position = new Vector3(x,0,0);
        }
    }
}
