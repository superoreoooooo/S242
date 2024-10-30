using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private Transform shootingP;
    public OVRInput.RawButton shootingBtn;
    public LayerMask lm;

    [SerializeField]
    private LineRenderer linePrefab;

    public AudioClip clip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingBtn))
        {
            Fire();
        }
    }

    public GameObject impact;

    void Fire()
    {
        audioSource.PlayOneShot(clip);
        Ray ray = new Ray(shootingP.position, shootingP.forward);
        bool isHit = Physics.Raycast(ray, out RaycastHit hit, 100, lm);
        Vector3 endP = Vector3.zero;

        if (isHit)
        {
            endP = hit.point;
        }
        else
        {
            endP = shootingP.position + shootingP.forward * 100;
        }

        LineRenderer lr = linePrefab;

        lr.positionCount = 2;
        lr.SetPosition(0, shootingP.position);
        lr.SetPosition(1, endP);

        StartCoroutine(del());

        GameObject obj = Instantiate(impact, hit.point, Quaternion.LookRotation(-hit.normal));
        
        Destroy(obj, 1f);
        //Destroy(lr.gameObject, 3);
    }

    private IEnumerator del()
    {
        yield return new WaitForSeconds(0.5f);
        linePrefab.SetPosition(0, Vector3.zero);
        linePrefab.SetPosition(1, Vector3.zero);
    }
}
