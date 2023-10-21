using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    public static EvidenceManager Instance;

    public List<Evidence> evidenceList = new List<Evidence>();
    void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        evidenceList.AddRange(FindObjectsOfType<Evidence>());
    }
}
