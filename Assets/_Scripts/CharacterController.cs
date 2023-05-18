using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<Animator> femaleBusiness, worker, spiderMan, police, thief;
    public Transform thiefBody;
    public GameObject thiefHuman, thiefAlien, thiefFace;
    public LayerMask humanLayer, alienLayer;
    
    private int arguingAnim = Animator.StringToHash("arguing");
    private int yellingAnim = Animator.StringToHash("yelling");
    private int fallingAnim = Animator.StringToHash("falling");
    private int hangingAnim = Animator.StringToHash("hanging");
    private int boxingAnim = Animator.StringToHash("boxing");
    private int hostageAnim = Animator.StringToHash("hostage");
    private int gunplayAnim = Animator.StringToHash("Gunplay");
    public void StartStageOne()
    {
        RunBothAnimator(femaleBusiness, arguingAnim);
        RunBothAnimator(worker, yellingAnim);
        RunBothAnimator(spiderMan, hangingAnim);
        
        // StartStageTwo();
    }

    public void StartStageTwo()
    {
        RunBothAnimator(police, gunplayAnim);
        RunBothAnimator(thief, hostageAnim);

        // thiefBody.DOShakePosition(1, new Vector3(.1f, .1f, .1f),randomness: 0).SetLoops(-1, LoopType.Yoyo);

        StartCoroutine(ChangeThiefLayer());
    }

    private IEnumerator ChangeThiefLayer()
    {
        int count = 0;
        while (true)
        {
            bool alien = count % 2 == 0;
            thiefHuman.layer = LayerMask.NameToLayer(alien? "Alien" : "Human");
            thiefFace.layer = LayerMask.NameToLayer(alien? "Alien" : "Human");
            thiefAlien.layer = LayerMask.NameToLayer(alien? "Human" : "Alien");
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void RunBothAnimator(List<Animator> animators, int anim)
    {
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].Play(anim);
        }
    }

    private void RunSingleAnimator(Animator animator, int anim)
    {
        animator.Play(anim);
    }
}
