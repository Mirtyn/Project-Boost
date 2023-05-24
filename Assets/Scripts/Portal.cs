using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject player;
    public GameObject[] FoundPortals;
    public int PortalTag;
    public GameObject OtherPortal;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MyPlayer");

        FoundPortals = GameObject.FindGameObjectsWithTag("Portal");

        int i = 0;
        foreach (GameObject g in FoundPortals)
        {
            if (FoundPortals[i].GetComponent<Portal>().PortalTag == this.PortalTag && FoundPortals[i] != this.gameObject)
            {
                this.OtherPortal = FoundPortals[i];
                break;
            }

            i++;
        }
    }

    public void TeleportPlayer()
    {
        Vector3 otherPortalUp = OtherPortal.transform.up;
        player.transform.position = new Vector3(OtherPortal.transform.position.x, OtherPortal.transform.position.y * otherPortalUp.y, OtherPortal.transform.position.z * otherPortalUp.z);
    }
}
