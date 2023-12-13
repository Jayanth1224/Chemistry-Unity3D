using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 15f;
    public Transform Molecule1;
    public Transform Molecule2;
    public GameObject labelPrefab;

    private GameObject label1;
    private GameObject label2;

    void Start()
    {
        label1 = Instantiate(labelPrefab, Molecule1.position + new Vector3(-1.5f, -3f, 0f), Quaternion.identity);
        label2 = Instantiate(labelPrefab, Molecule2.position + new Vector3(-2f, -1f, 0f), Quaternion.identity);

        label1.transform.parent = transform;
        label2.transform.parent = transform;

        // Get the TextMesh component from the instantiated labels
        TextMesh textMesh1 = label1.GetComponentInChildren<TextMesh>();
        TextMesh textMesh2 = label2.GetComponentInChildren<TextMesh>();

        if (textMesh1 != null && textMesh2 != null)
        {
            // Set text for labels
            textMesh1.text = "Molecule 1";
            textMesh2.text = "Molecule 2";
        }
        else
        {
            Debug.LogError("TextMesh component not found on label prefab.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the model arounf its y-axis
        Molecule1.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        Molecule2.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
