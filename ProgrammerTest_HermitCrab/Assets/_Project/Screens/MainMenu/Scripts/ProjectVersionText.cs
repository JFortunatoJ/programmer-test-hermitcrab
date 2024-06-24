using TMPro;
using UnityEngine;

public class ProjectVersionText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = $"v{Application.version}";
    }
}
