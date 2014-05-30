using UnityEngine;
using System.Collections;

public class AnimationChooser : MonoBehaviour 
{
    AnimationState anim;

    void Start()
    {
        //animation.CrossFadeQueued("SwordSwingLowLeft");
		//animation.CrossFadeQueued("Charge");
		//anim.blendMode = AnimationBlendMode.Additive;
        animation.Play("SwordDuckBelow");
		//anim.blendMode = AnimationBlendMode.Additive;
        anim = animation["SwordDuckBelow"];
    }

    void Update()
    {
		//Debug.Log("anim.normalizedTime : "+anim.normalizedTime);
        if (anim.normalizedTime >= 0.99f)
        {
            Debug.Log("animation3 is finished");
			animation["Charge"].wrapMode=WrapMode.Loop;
			animation.Play("Charge");
        }
    }
}
