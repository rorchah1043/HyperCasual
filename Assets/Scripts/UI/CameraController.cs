using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject resourcesCameraPosition;
        [SerializeField] private GameObject battleCameraPosition;

        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;

        private State _state = State.Resources;
        
        public void ToggleMove()
        {
            switch (_state)
            {
                case State.Resources:
                    StartCoroutine(MoveToObject(State.Battle));
                    break;
                case State.Battle:
                    StartCoroutine(MoveToObject(State.Resources));
                    break;
                case State.Moving:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator MoveToObject(State targetState)
        {
            _state = State.Moving;
            var speed = 0f;

            GameObject target;
            switch (targetState)
            {
                case State.Battle:
                    target = battleCameraPosition;
                    break;
                case State.Resources:
                    target = resourcesCameraPosition;
                    break;
                case State.Moving:
                default:
                    yield break;
            }
            var targetPosition = target.transform.position;
            while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                float stepDistance;

                var stopDistance = (speed * speed) / (2 * acceleration);
                var totalDistance = Vector3.Distance(targetPosition, transform.position);
                if (stopDistance > totalDistance)
                {
                    stepDistance = speed * Time.deltaTime - acceleration * Time.deltaTime * Time.deltaTime / 2;
                    speed = Math.Max(0f, speed - acceleration * Time.deltaTime);
                }
                else
                {
                    if (speed == maxSpeed)
                    {
                        stepDistance = speed * Time.deltaTime;
                    }
                    else
                    {
                        var fullSpeedTime = (maxSpeed - speed) / acceleration;
                        if (fullSpeedTime > Time.deltaTime)
                        {
                            stepDistance = speed * Time.deltaTime + acceleration * Time.deltaTime * Time.deltaTime / 2;
                            speed += acceleration * Time.deltaTime;
                        }
                        else
                        {
                            stepDistance = speed * fullSpeedTime + acceleration * fullSpeedTime * fullSpeedTime / 2 +
                                           maxSpeed * (Time.deltaTime - fullSpeedTime);
                            speed = maxSpeed;
                        }
                    }
                }

                transform.position = Vector3.MoveTowards(transform.position, targetPosition, stepDistance);

                yield return null;
            }

            _state = targetState;
        }

        private enum State
        {
            Resources,
            Battle,
            Moving
        }
    }
}