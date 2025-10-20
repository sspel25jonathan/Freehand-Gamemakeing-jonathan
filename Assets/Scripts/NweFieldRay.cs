using System.Collections;
using UnityEngine;

public class NweFieldRay : MonoBehaviour
{
    public LayerMask layerMask;

    public float range;
    public GameObject thing;
    public GameObject target;
    void Start()
    {

        StartCoroutine(ShootingRays()); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform, Vector3.forward);
    }

    private IEnumerator ShootingRays()
    {
        RaycastHit hit;
        while (true){
            Physics.Raycast(thing.transform.position, thing.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);
            //TOBBE TESTAR
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player") &&  Vector3.Distance(this.transform.position, target.transform.position) < 4) {
                    Debug.Log("hitting player and it is CLOSE!");
                yield return new WaitForSeconds(1);
            }if (hit.collider.CompareTag("Player")) {
                    Debug.Log("hitting player");
                yield return new WaitForSeconds(1);
            }
            else
            {
                    Debug.Log("hit something else");
                yield return new WaitForSeconds(1);
            }
            }
            
            yield return new WaitForSeconds(1);
        }
    }
}
