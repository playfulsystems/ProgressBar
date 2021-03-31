using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	// reference to the bar
	public GameObject progressBar;
	float initialXScale;

	// number of hits to fill the bar
	public int numHitsRequired = 5;
	int numHits = 0;

	// in this case, I'm going to consider the following mapping:
	// 0 is the up arrow
	// 1 is the bottom arrow
	// i.e. if the 
	int nextButtonToHit = 0;
	int numButtonsToHit = 2;

	// Use this for initialization
	void Start () {

		// i've already altered the x scale in the editor, so I need to get what that is
		initialXScale = progressBar.transform.localScale.x;

		// reset it to zero so there is no red bar initially
		progressBar.transform.localScale = new Vector2(0, progressBar.transform.localScale.y);
	}

	// Update is called once per frame
	void Update () {

		// calculate percentage done (a number between 0 and 1)
		float pecentDone = numHits*1.0f/numHitsRequired;

		// multiply the percentage by the original scale (of what the bar looks like full)
		progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);

		// if the bar isn't full
		if (numHits < numHitsRequired) {

			// if button down and the right button to hit is needed, add to the number of hits
			if (Input.GetKeyDown(KeyCode.UpArrow) && nextButtonToHit == 0) {
				numHits++;

				// note, % is "the remainder" — this effectively goes through the pattern:
				// 0, 1, 0, 1, 0, 1...
				nextButtonToHit = (nextButtonToHit+1) % numButtonsToHit;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) && nextButtonToHit == 1) {
				numHits++;

				// note, % is "the remainder"
				nextButtonToHit = (nextButtonToHit+1) % numButtonsToHit;
			}
		}
		
	}
}
