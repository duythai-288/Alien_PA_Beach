using System.Collections;
using UnityEngine;

public class UFOModel : MonoBehaviour
{
    Vector3 rotateStep = new Vector3(0, 1f, 0);
    public MeshRenderer pipeLight;
    // Start is called before the first frame update
    void Start()
    {
        Color newColor = pipeLight.materials[0].color;
        newColor.a = 0;
        pipeLight.materials[0].color = newColor;
        if (transform.parent.name.Contains("Decorate"))
        {
            ShowUFOPipeLight();
        }
        //transform.DOMoveY(transform.position.y - 0.7f, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }


    private void Update()
    {
        transform.Rotate(rotateStep);
    }

    public void ShowUFOPipeLight() {
        StartCoroutine(PlayEmotion());
    }

    public void HideUFOPipeLight()
    {

    }
    IEnumerator PlayEmotion()
    {
        Color newColor = pipeLight.materials[0].color;
        WaitForSeconds delayTime = new WaitForSeconds(0.01f);
        float alpha = 0f;
        while (alpha < 0.5f)
        {
            alpha += 0.005f;
            newColor.a = alpha;
            pipeLight.materials[0].color = newColor;
            yield return delayTime;
        }
    }
}
