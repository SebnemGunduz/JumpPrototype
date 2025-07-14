using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
