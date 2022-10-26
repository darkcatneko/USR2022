using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerCatchController : MonoBehaviour
{
    [SerializeField] private Transform catchPoint;
    [SerializeField] private _SwipeDetection swipeDetection;
    [SerializeField] private _GameDataCtr gameDataCtr;
    [SerializeField] private Animator handAnimator;

    private GameObject lookAtGoods;
    private GameObject holdingGoods;

    public float catchDistance = .5f;
    public float rotateSpeed = 1f;

    public Coroutine coroutine;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 40f);     //�������S���ݵ۳f��
        RaycastHit hit;
        if (holdingGoods == null && Physics.Raycast(ray, out hit, 40f, 1 << 8)) 
        {
            lookAtGoods = hit.collider.gameObject;
        }
        else
        {
            lookAtGoods = null;
        }

        if (lookAtGoods != null && Vector3.Distance(lookAtGoods.transform.position, Camera.main.transform.position) <= catchDistance)   //�p�G�ݵ۳f���S����ܪ�h����f��
        {
            holdingGoods = lookAtGoods;
            holdingGoods.GetComponent<_GoodsMovement>().Catched();
            holdingGoods.transform.position = catchPoint.transform.position;
            holdingGoods.transform.parent = catchPoint;
            handAnimator.SetTrigger("catch");
        }

        if (holdingGoods != null) //�p�G���۳f���h�P�_�ưʤ�V
        {
            GoodsType holdingGoodsType = holdingGoods.GetComponent<_GoodsData>().goodsType;

            if (swipeDetection.isSwiped) //�O�_�ư�
            {
                switch (swipeDetection.swipeDirectionType)
                {
                    case _SwipeDetection.SwipeDirectionType.Up:
                        break;
                    case _SwipeDetection.SwipeDirectionType.Down:
                        if (holdingGoodsType == GoodsType.RedGoods)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                    case _SwipeDetection.SwipeDirectionType.Left:
                        if (holdingGoodsType == GoodsType.YellowGoods)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        coroutine = StartCoroutine("RotateHand", -rotateSpeed);
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                    case _SwipeDetection.SwipeDirectionType.Right:
                        if (holdingGoodsType == GoodsType.BlueGoods)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        coroutine = StartCoroutine("RotateHand", rotateSpeed);
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                }
            }
            
        }

        swipeDetection.isSwiped = false;
    }

    private IEnumerator RotateHand(float rotateSpeed)
    {
        int frame = 0;
        while (frame <= 70) 
        {
            handAnimator.transform.rotation = Quaternion.Euler(handAnimator.transform.rotation.eulerAngles + Vector3.up * rotateSpeed);
            frame++;
            yield return null;
        }
        frame = 0;
        while (frame <= 70)
        {
            handAnimator.transform.rotation = Quaternion.Euler(handAnimator.transform.rotation.eulerAngles + Vector3.up * -rotateSpeed);
            frame++;
            yield return null;
        }
        StopCoroutine(coroutine);
    }
}
