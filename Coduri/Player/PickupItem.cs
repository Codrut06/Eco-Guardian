using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    //public GameObject destroyEffect;

    public Vector3 Direction { get; set; }
    private GameObject itemHolding;

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //cand tasta E este apasata putem lua un item de pe jos
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;

                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }

        //cand tasta Q este apasata putem arunca acel item in directia de miscare a playerul-ui
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemHolding)
            {
                ThrowItem(itemHolding);
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }
        }
    }

    //functia care arunca item-ul tinut de player
    private void ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;


        item.transform.position = Vector3.Lerp(startPoint, endPoint, 25 * .04f);
        Object.Destroy(item, 0.05f);

    }

}
