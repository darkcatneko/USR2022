using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _PlayerActionClass : MonoBehaviour
{
    //��controller�]�w��parent
    public _PlayerActController parent;
    public GameObject hand;
    //�Ҧ�Action���J(�}�l)�ɳ��|�I�s�@��
    protected virtual void Start()
    {
        //��controller�]�w��parent
        hand = GameObject.FindGameObjectWithTag("hand");
        parent = GetComponent<_PlayerActController>();


        Action();
    }

    //�Ҧ�Action���n����function
    protected abstract void Action();
    protected abstract IEnumerator Move();

    public virtual void SkillFinish()
    {
        //��o��script�qobj�W�R��
        Destroy(this);



        //�sController�h�U�@�Ӱʧ@
        //parent.NextMove();    ���controller�M���a�I��
    }

    public virtual void StopAttack()
    {
        StopCoroutine(Move());
        Destroy(this);
    }
}