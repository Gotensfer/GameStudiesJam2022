using UnityEngine;

public class Exercise1Mechanic : MonoBehaviour
{
    [SerializeField] private GameObject coll;
    [SerializeField] ParticleSystem ps;
    float time=0.2f;
    private void Update()
    {
        if (coll.activeSelf) return; 
        if (Input.GetButtonDown("Jump"))
        {
            ShieldStart();
            Invoke("Teleport",0.2f);
            Invoke("Origin", 2f);


        }
    }


    private void ShieldStart()
    {   
        

        ps.Play(true);

    }

    private void Teleport()
    {
        transform.position = new Vector3(0f, 1f, 0f);
    }

    private void Origin()
    {
        transform.position = new Vector3(0f, 1f, -5f);
    }
}
