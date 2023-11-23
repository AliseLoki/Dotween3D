using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsMarked { get; private set; } = false;

    public void SetMarked()
    {
        IsMarked = true;
    }
}
