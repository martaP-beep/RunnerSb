using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject floorTile1;
    public GameObject floorTile2;

    public GameObject[] tiles;

   
    void FixedUpdate()
    {
        floorTile1.transform.position -=
            new Vector3(GameManager.instance.worldScrollingSpeed, 0, 0);

        floorTile2.transform.position -=
            new Vector3(GameManager.instance.worldScrollingSpeed, 0, 0);

        if(floorTile2.transform.position.x < 0)
        {
            //floorTile1.transform.position += new Vector3(32, 0, 0);

            var newTile = Instantiate(tiles[Random.Range(0, tiles.Length)],
                floorTile2.transform.position + new Vector3(16,0,0), 
                Quaternion.identity);

            Destroy(floorTile1);

           // var x = floorTile1;
            floorTile1 = floorTile2;
            floorTile2 = newTile;
        }


    }
}
