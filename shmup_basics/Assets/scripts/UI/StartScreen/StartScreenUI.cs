using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace rr.ui {

    public enum CursorMoveType {
        Jump,
        Slide
    }

    public class StartScreenUI : MonoBehaviour {

        public Color uiActiveElementColor;
        public Color uiInactiveElementColor;
        public Image uiCursor;
        public CursorMoveType cursorMoveType = CursorMoveType.Jump;
        public float cursorBlinkingPeriod = 0f;
        public float cursorSensibility = 0.5f;
        public int activeOptionIndex = 0;
        public List<Text> uiOptions;

        private float _nextRecordedInput = 0f;
        private float _nextBlink = 0f;

        void Update() {
            var vAxis = Input.GetAxis("Vertical_1");
            var time = Time.realtimeSinceStartup;
            if(Mathf.Abs(vAxis) > 0 && time > _nextRecordedInput) {
                uiCursor.gameObject.SetActive(true);
                _nextRecordedInput = time + cursorSensibility;

                if (vAxis > 0) {
                    activeOptionIndex -= 1;
                }
                else if (vAxis < 0) {
                    activeOptionIndex += 1;
                }

                if (activeOptionIndex >= uiOptions.Count)
                    activeOptionIndex = 0;

                if (activeOptionIndex < 0)
                    activeOptionIndex = uiOptions.Count - 1;

                ActiveOption(activeOptionIndex);
            }
            else if (cursorBlinkingPeriod > 0) {
                if(_nextBlink == 0) {
                    _nextBlink = time + cursorBlinkingPeriod;
                }
                else if(time > _nextBlink) {
                    uiCursor.gameObject.SetActive(!uiCursor.gameObject.activeSelf);
                    _nextBlink = time + cursorBlinkingPeriod;
                }
            }

            if(Input.GetButton("Fire_1")) {
                uiOptions[activeOptionIndex].GetComponent<UILink>().Activate();
            }
        }

        private void ActiveOption(int index) {
            var activeOption = uiOptions[index];
            foreach(var opt in uiOptions) {
                opt.color = uiInactiveElementColor;
            }

            activeOption.color = uiActiveElementColor;
            var currentPos = uiCursor.transform.position;
            switch(cursorMoveType) {
                case CursorMoveType.Slide:
                    var effect = uiCursor.GetComponent<UITransformEffect>();
                    effect.from = currentPos;
                    effect.to = new Vector2(currentPos.x, activeOption.transform.position.y);
                    effect.enabled = true;
                    break;
                case CursorMoveType.Jump:
                default:
                    uiCursor.transform.position = new Vector2(currentPos.x, activeOption.transform.position.y);
                    break;
            }
        }
    }
}


