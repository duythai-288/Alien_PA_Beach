using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AlienDead : MonoBehaviour
{
    public List<Animator> alienAnimators;

    public GameObject humanBody, alienBody, bodyParent;
    public LayerMask humanLayer, alienLayer;
    private int fallingAnim = Animator.StringToHash("falling");
    private int deadAnim = Animator.StringToHash("death");

    IEnumerator DeadAnim()
    {
        float deadTime = 0f;

        while (deadTime < 1f)
        {
            deadTime += .1f;
            humanBody.layer = alienLayer;
            alienBody.layer = humanLayer;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AlienDeadAnim()
    {
        // humanBody.layer = alienLayer;

        // for (int i = 0; i < alienAnimators.Count; i++)
        // {
        //     alienAnimators[i].Play(fallingAnim);
        // }
        // transform.eulerAngles = new Vector3(-180, 0, 0);
        AudioController.Instance.PlayOne(2);

        transform.DOLocalMove(new Vector3(0, 1, -.5f), .1f);
        alienAnimators[1].Play(fallingAnim);
        humanBody.SetActive(false);
        alienBody.layer = LayerMask.NameToLayer("Human");

        transform.DOShakePosition(1, Vector3.one, 60);
        transform.DOShakeRotation(1,Vector3.one, 60).OnComplete(
            () =>
            {
                transform.DOLocalMove(new Vector3(0, 3, -2), .01f);
                transform.DOLocalRotate(new Vector3(0, 120, 180), .01f);
                alienAnimators[1].Play(deadAnim);
                StartCoroutine(GameController.Instance.ShowEndCard());
                transform.DOLocalMoveY(5, 7f);
            }
        );
    }
}