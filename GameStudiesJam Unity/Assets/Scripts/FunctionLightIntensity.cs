using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FunctionLightIntensity : MonoBehaviour {

    enum State
    {
        Stopped = 0,
        Playing = 1
    }

    [SerializeField] private State state = State.Stopped;

    [SerializeField] private Light light;
    [SerializeField] private AnimationCurve aCurve;
    [SerializeField] private float duration=1;

    private float inLIn;


    private float time = 0;

   
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (state == State.Stopped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Playing;
                Assert.IsNotNull(light);
            }
        }

        if (state == State.Playing)
        {
            time += Time.deltaTime;
            light.intensity = aCurve.Evaluate(time/duration);

            if (time >= duration)
            {
                state = State.Stopped;
                time = 0;
            }
        }
    }
}
