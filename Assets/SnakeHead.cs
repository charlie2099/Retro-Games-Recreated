using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private List<Transform> _tailPartsList = new();

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            //GrowTail();
            Destroy(other.gameObject);
        }
    }

    private void GrowTail()
    {
        Transform endTailPart = _tailPartsList[_tailPartsList.Count-1];
        Vector3 newTailPartPosition = endTailPart.position + new Vector3(-1.1F,0,0);
        GameObject newTailPart = Instantiate(_tailPrefab);
        newTailPart.transform.position = newTailPartPosition;
        newTailPart.transform.SetParent(transform);
        _tailPartsList.Add(newTailPart.transform);
    }
}
