using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimboWell_sc : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject player;
    public LimboTrigger_sc limboSc;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(santelmo());
        }
    }

    private IEnumerator santelmo()
    {
        dialog1.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        dialog1.SetActive(false);
        dialog2.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        dialog2.SetActive(false);
        yield return new WaitForSecondsRealtime(3f);
        player.transform.position = new Vector3(1205.8f, 16.2f, 933.6f);
        limboSc.limboTrigger.SetActive(false);
    }

}
