using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LimboTrigger_sc : MonoBehaviour
{
    public GameObject player;
    public GameObject hand;
    public GameObject ashMound;
    public GameObject sugarcanes;
    public GameObject limboTrigger;
    public AudioSource oooouu;

    public PlayerMov_sc player_sc;

    public bool trigger = false;
    public float handRunTime;
    public bool handDeleted = false;

    private void Start()
    {

    }
    private void Update()
    {
        if (trigger)
        {
            StartCoroutine(activateLimbo());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
    }

    private IEnumerator activateLimbo()
    {
        oooouu.enabled = true;
        player_sc.canMove = false;
        if (!handDeleted)
        {
            hand.transform.position += (Vector3.up * 1.7f) * Time.deltaTime;
            Debug.Log("Stoped");
        }
        yield return new WaitForSecondsRealtime(3f);
        player.transform.position = new Vector3(38f, 6.5f, 1761f);
        player_sc.canMove = true;
        hand.SetActive(false);
        sugarcanes.SetActive(false);
        ashMound.SetActive(true);
        trigger = false;
    }
}
