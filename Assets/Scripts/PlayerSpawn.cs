using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] TileOneRowOneTile genPortal;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera camera;
    void Start()
    {
        camera = FindObjectOfType<CinemachineVirtualCamera>();
        StartCoroutine(PlayerSpawnCor());
    }

    IEnumerator PlayerSpawnCor()
    {
        var newPlayer = Instantiate(player, new Vector3((float)genPortal.savedPos.x + genPortal.map.layoutGrid.transform.position.x,
        (float)genPortal.savedPos.y + genPortal.map.layoutGrid.transform.position.y,
        (float)genPortal.savedPos.z + genPortal.map.layoutGrid.transform.position.z), Quaternion.identity);
        player = newPlayer;
        yield return new WaitForSeconds(.5f);
        SetFollow();
        yield return new WaitForSeconds(5f);
        ErasePortal();
        yield return null;
    }

    public void SetFollow()
    {
        var vcam = camera.GetComponent<CinemachineVirtualCamera>();
        vcam.LookAt = player.transform;
        vcam.Follow = player.transform;
    }

   public void ErasePortal()
    {
        genPortal.map.SetTile(genPortal.savedPos, null);
    }
}
