using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Room : MonoBehaviour
{
    public int[] dimensions;
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    Vector3 position;
    void Start()
    {
        int x = 0;
        for(int i = 0; i <= dimensions[0]; i++){
            position.x = x;
            float y = -.75f;
            position.y = y;
            Instantiate(floorPrefab, position, Quaternion.identity);
            x++;
            for(int u = 0; u < dimensions[1]; u++)
            {
                y--;
                position.y = y;
                Instantiate(floorPrefab, position, Quaternion.identity);
            }
            position.y = .25f;
            Instantiate(wallPrefab, position, Quaternion.identity);
        }
    }
}
