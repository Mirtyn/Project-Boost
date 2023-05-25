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
        Vector3 playerPos = player.transform.position;
        Quaternion playerRotation = player.transform.rotation;

        Vector3 otherPortalPos = OtherPortal.transform.position;
        Vector3 otherPortalUpDirection = OtherPortal.transform.up;
        Quaternion otherPortalRotation = OtherPortal.transform.rotation;

        float spawnDistance = 2.5f;

        Vector3 teleportPos = otherPortalPos + otherPortalUpDirection * spawnDistance;
        Quaternion teleportRot = new Quaternion(0, 0, playerRotation.z + otherPortalRotation.z, playerRotation.w + otherPortalRotation.w);

        player.transform.position = teleportPos;
        player.transform.rotation = teleportRot;
    }
}
