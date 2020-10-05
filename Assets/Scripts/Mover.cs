using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Transform currentTarget;
    private Animator _anim;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == startPoint.position)
        {
            currentTarget.position = endPoint.position;
            _anim.SetBool("Change",false);
        }
        else if(transform.position == endPoint.position)
        {
            currentTarget.position = startPoint.position;
            _anim.SetBool("Change",true);
        }
        transform.position = Vector2.MoveTowards(transform.position,currentTarget.position,2*Time.deltaTime);
    }
}
