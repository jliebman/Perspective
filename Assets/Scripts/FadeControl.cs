namespace WorkZoneSafety.Utility {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[RequireComponent(typeof(Animator))]
	public class FadeControl : MonoBehaviour {

		public Material FTBCubeMat;
		public float FadeAtTimeInSeconds = 30f;
		private Animator animator;
		private bool loading = false;

		void Awake() {
#if UNITY_EDITOR
			FTBCubeMat.color = Color.clear;
#else
			FTBCubeMat.color = Color.black;
#endif
			animator = GetComponent<Animator> ();
		}

		// Use this for initialization
		void Start () {
#if !UNITY_EDITOR
			StartCoroutine (FadeToClear ());
#endif
		}
		
		// Update is called once per frame
		void Update () {
#if !UNITY_EDITOR
			if (!loading) {
				AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
				float currentTime = animator.GetCurrentAnimatorClipInfo (0) [0].clip.length * state.normalizedTime;
				if (currentTime >= FadeAtTimeInSeconds) {
					StartCoroutine (FadeToBlack());
					loading = true;
				}
			}
#endif
		}

		IEnumerator FadeToClear() {
			while (FTBCubeMat.color.a > 0) {
				Color color = FTBCubeMat.color;
				color.a -= 0.1f;
				FTBCubeMat.color = color;
				yield return null;
			}
		}

		IEnumerator FadeToBlack() {
			while (FTBCubeMat.color.a < 1) {
				Color color = FTBCubeMat.color;
				color.a += 0.05f;
				FTBCubeMat.color = color;
				yield return null;
			}
			StartCoroutine (LoadEndScene ());
		}

		IEnumerator LoadEndScene() {
			AsyncOperation ao = SceneManager.LoadSceneAsync (2);
			while (!ao.isDone) {
				// Add anything here
				yield return null;
			}
		}
	}
}