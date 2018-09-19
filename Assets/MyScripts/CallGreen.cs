using UnityEngine;
using System.Collections;

public class CallGreen : MonoBehaviour {
   public Animator greenanim;
   public Animator redanim;
   public Animator yellowanim;

    void Start ()
    {
        greenanim.GetComponent<Animator>();
        redanim.GetComponent<Animator>();
        yellowanim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        int val=Sending.Update();
        print(val);
        if (val == 1)
        {
            print("play");
            redanim.Play("redcube");
            yellowanim.Play("yellowcube");
            greenanim.Play("greencube");
        }
        if (val == 2)
        {
            print("stop");
            redanim.Play("none");
            yellowanim.Play("none");
            greenanim.Play("none");
        }
    }
	 void OnMouseDown() {
	 	print("Clicked");
	 	Sending.sendGreen();
    }
}
