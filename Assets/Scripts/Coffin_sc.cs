using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coffin_sc : MonoBehaviour
{
    public CharacterController coffinControler;
    public GameObject playerGO;
    public Collider treeCol1;
    public Collider treeCol2;

    public float movSpeed;
    public bool canMove;
    public float setMovSpeed;

    public bool startChase = false;
    void Start()
    {
        setMovSpeed = movSpeed;
        canMove = true;
    }

    
    void Update()
    {
        if (startChase)
        {
            transform.LookAt(playerGO.transform);

            if (canMove)
            {
                coffinControler.Move(transform.forward * movSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, playerGO.transform.position) <= 30f)
            {
                StartCoroutine(stutter());
                movSpeed = 60f;
            }
            else if (Vector3.Distance(transform.position, playerGO.transform.position) >= 40f)
            {
                canMove = true;
                if (Vector3.Distance(transform.position, playerGO.transform.position) >= 60f)
                {
                    movSpeed = 120f;
                }
            }
        }
    }

    public IEnumerator stutter()
    {
        canMove = false;
        yield return movSpeed;
        SceneManager.LoadScene(0);
        Debug.Log("0 movement speed");
    }

    public bool setBoolChase()
    {
        startChase = true;
        return startChase;
    }
}
