﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjects : MonoBehaviour{
    
    private Vector3 fixedTarget;
    
    [Header("Настройки следования за объектом")]
    public Transform targetTransform; //Сам объект
    [Range(0.001f,1f)] public float delta = 0.85f; //Дельта
    public bool useX = true;
    public bool useY = true;
    public float minHeight = 3.76f;
    public float zCamCoord = -10f;
    
    private void Awake(){
        Application.targetFrameRate = 300;
    }

    private void FixedUpdate(){
        if (targetTransform != null){
            float fixedTargetY = Mathf.Clamp(targetTransform.position.y, minHeight-0.2f,1000);
            if (useX && useY)
                fixedTarget = new Vector3(targetTransform.position.x, fixedTargetY, zCamCoord);
            if (!useX && !useY)
                fixedTarget = transform.position;
            if (!useX && useY)
                fixedTarget = new Vector3(transform.position.x, fixedTargetY, zCamCoord);
            if (useX && !useY)
                fixedTarget = new Vector3(targetTransform.position.x, fixedTargetY, zCamCoord);
            
            Vector3 finalVector = Vector3.Lerp(transform.position, fixedTarget, delta);
            transform.position = finalVector;
        }
    }
}
