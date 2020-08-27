using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform statement stops generation past 20^3 (8000) cubes
        // 1 - 20 - 400 - 8000 - 160000 - 3200000
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && transform.localScale.x > 1)
        {
           
            //Create new cubes
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        //Exclude centre cube
                        if (!(i == 0 && j == 0 && k == 0))
                        {
                            //Exclude centre-of-face cubes
                            if (!((i == 0 && j == 0) || (i == 0 && k == 0) || (j == 0 && k == 0)))
                                CreateCube(i, j, k);
                        }
                    }
                }
            }

            Destroy(gameObject);
        }
    }

    void CreateCube(int x, int y, int z)
    {
        SpongeBuilder newCube;
        Vector3 pos = transform.position;
        Vector3 newPos = pos;
        if (x == -1) newPos.x = pos.x - transform.localScale.x / 3;
        if (x == 1) newPos.x = pos.x + transform.localScale.x / 3;
        if (y == -1) newPos.y = pos.y - transform.localScale.y / 3;
        if (y == 1) newPos.y = pos.y + transform.localScale.y / 3;
        if (z == -1) newPos.z = pos.z - transform.localScale.x / 3;
        if (z == 1) newPos.z = pos.z + transform.localScale.x / 3;


        newCube = Instantiate(this, transform.position, Quaternion.identity, transform.parent);
        newCube.transform.localScale = transform.localScale / 3;
        newCube.transform.position = newPos;
    }
}
