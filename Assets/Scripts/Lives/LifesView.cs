using System.Collections.Generic;
using UnityEngine;

public class LifesView : MonoBehaviour
{
    [SerializeField] List<GameObject> lifes;

    public void DecreaseLife(int index)
    {
        lifes[index].SetActive(false);
    }
}
