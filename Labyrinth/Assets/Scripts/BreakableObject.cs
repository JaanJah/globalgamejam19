﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private int NumberOfClicks { get; set; }
    public GameObject Player;

    public AudioClip BreakNoise;
    public GameObject Cover;
    public GameObject Room;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfClicks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()  
    {
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 1.7 && gameObject.name == "Secret Wall")
        {
            NumberOfClicks++;
            gameObject.GetComponent<AudioSource>().PlayOneShot(BreakNoise);
            if (NumberOfClicks >= 4)
            {
                Thread.Sleep(250);
                Destroy(gameObject);
                Destroy(Cover);
                Room.SetActive(true);
            }
            return;
        }
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 1.7)
        {
            NumberOfClicks++;
            gameObject.GetComponent<AudioSource>().PlayOneShot(BreakNoise);
            shakeGameObject(gameObject, 0.5f, 0.1f, true); 
        }
    }

    void shakeGameObject(GameObject objectToShake, float shakeDuration, float decreasePoint, bool objectIs2D)
    {
        StartCoroutine(shakeGameObjectCOR(objectToShake, shakeDuration, decreasePoint, true));
    }

    IEnumerator shakeGameObjectCOR(GameObject objectToShake, float totalShakeDuration, float decreasePoint, bool objectIs2D)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            Debug.LogError("decreasePoint must be less than totalShakeDuration...Exiting");
            yield break; //Exit!
        }

        //Get Original Pos and rot
        Transform objTransform = objectToShake.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        float counter = 0f;

        //Shake Speed
        const float speed = 0.1f;

        //Angle Rotation(Optional)
        const float angleRot = 4;

        //Do the actual shaking
        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;
            float decreaseAngle = angleRot;

            //Shake GameObject
            if (objectIs2D)
            {
                //Don't Translate the Z Axis if 2D Object
                Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                tempPos.z = defaultPos.z;
                objTransform.position = tempPos;

                //Only Rotate the Z axis if 2D
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            }
            else
            {
                objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            }
            yield return null;


            //Check if we have reached the decreasePoint then start decreasing  decreaseSpeed value
            if (counter >= decreasePoint)
            {
                //Reset counter to 0 
                counter = 0f;
                while (counter <= decreasePoint)
                {
                    counter += Time.deltaTime;
                    decreaseSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    decreaseAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);

                    //Shake GameObject
                    if (objectIs2D)
                    {
                        //Don't Translate the Z Axis if 2D Object
                        Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        tempPos.z = defaultPos.z;
                        objTransform.position = tempPos;

                        //Only Rotate the Z axis if 2D
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));
                    }
                    else
                    {
                        objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(1f, 1f, 1f));
                    }
                    yield return null;
                }

                //Break from the outer loop
                break;
            }
        }
        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;//Reset to original rotation

        if (NumberOfClicks >= 4)
        {
            Thread.Sleep(250);
            Destroy(gameObject);
        }
    }
}
