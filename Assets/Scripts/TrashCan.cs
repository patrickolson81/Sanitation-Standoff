using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    public GameObject pointPopup;

    void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
    }
    
    public void InsideTrash(GameObject go)
    {
        Instantiate(pointPopup, this.transform.position, Quaternion.identity);
        AudioManager.instance.Play("TrashCan");
        Destroy(go);
    }
}
