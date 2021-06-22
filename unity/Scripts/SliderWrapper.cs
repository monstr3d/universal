using System;
using System.Collections.Generic;
using Unity.Standard.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Standard
{ 
    /// <summary>
    /// Slider wrapper
    /// </summary>
    public class SliderWrapper : AbstractIndicator
    {
        #region Fields

        public float scale;

        Color current;


        protected bool isVisible = true;

        protected Func<bool> exceeds;



        // public float ratio = 0.5f;

        public Color normal = new Vector4(0, 1, 0, 1);

        public Color exceed = new Vector4(1, 0, 0, 1);

  
        protected Dictionary<string, List<Component>> components;

        protected Component component;

        protected  float currentValue;

        protected Slider left;

        protected Slider right;

        GameObject gameObject;

        protected  Action<float> setFloatValue;

        private Action<bool> disableSliders;

        string initialText = "";

        Text text;

        string format = "0.00";

        Action updateText;

        Slider[][] sliders;

        protected float limit;

        Sign sign = Sign.positive;

        enum Sign
        {
            positive,
            negative
        }

        bool enableDebug = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <param name="component">Component</param>
        /// <param name="scale">Scale</param>
        /// <param name="limit">Limit</param>
        /// <param name="output">Output</param>
        /// <param name="normal">Normal color</param>
        /// <param name="exceed">Exceed color</param>
        /// <param name="format">Format</param>
        public SliderWrapper(string parameter, Component component,
          float scale, float limit, Func<double> output, Color normal, Color exceed, string format, bool enableDebug) :
            this(parameter, component, scale, limit, output, enableDebug)
        {
            this.normal = normal;
            this.exceed = exceed;
            this.format = format;
            current = normal;
            if (left != null)
            {
                left.GetComponentInChildren<Image>().color = normal;
                left.fillRect.sizeDelta = new Vector2(0, 0);
                right.fillRect.sizeDelta = new Vector2(0, 0);
                right.value = 0;
                right.GetComponentInChildren<Image>().color = exceed;
            }

        }

        public SliderWrapper(string parameter, Component component,
            float scale, float limit, Func<double> output = null, bool enableDebug = false)
        {
            this.parameter = parameter;
            Find();
            obj = (double)0;
            this.enableDebug = enableDebug;
            setValue = (object o) =>
            {
                Set(o);
                updateText?.Invoke();
                setValue = Set;
            };
            type = obj;
            this.component = component;
            SetActive(true);
            if (!enableDebug)
            {
                SetActive(false);
            }
            components = component.gameObject.GetGameObjectComponents<Component>();
            this.scale = scale;
            this.limit = limit;
            current = normal;
            gameObject = component.gameObject;
            if (components.ContainsKey("ValueText"))
            {
                var vt = components["ValueText"];
                text = vt[0].gameObject.GetComponent<Text>();
                initialText = text.text;
                updateText = UpdateText;
            }
            if (components.ContainsKey("SliderLeft"))
            {
                CreatePositive();
            }
            else
            {
                CreateNegative();
            }
            update = () =>
            {
                setFloatValue(GetValue(output()));
            };
            this.Add();
        }

        #endregion

        #region Public Members

        public override string ToString()
        {
            return parameter;
        }

        /// <summary>
        /// Initial text
        /// </summary>
        public string InitialText
        {
            set
            {
                initialText = value;
            }
        }


        // Update is called once per frame
        public void Update()
        {
            update?.Invoke();
            updateText?.Invoke();
        }

        /// <summary>
        /// Sets Value
        /// </summary>
        public double Value
        {
            set
            {
                setFloatValue(GetValue(value));
                updateText?.Invoke();
            }
        }


        #endregion

        #region Protected Members

        /// <summary>
        /// Sets visible sign
        /// </summary>
        /// <param name="visible">The sign value</param>
        protected void SetVisible(bool visible)
        {
            if (visible == isVisible)
            {
                return;
            }
            isVisible = visible;
            disableSliders(visible);
            text.gameObject.SetActive(visible);
            if (!visible)
            {
               // text.enabled []
                return;
            }
            updateText?.Invoke();
            setFloatValue(currentValue);
        }

        #endregion

        #region Private Members

        void UpdateText()
        {
            if (!isVisible)
            {
                return;
            }
            if (text.color != current)
            {
                text.color = current;
            }
            text.text = initialText + currentValue.ToString(format);
        }


  
        float GetValue(double val)
        {
            currentValue = scale * (float)val;
            return currentValue;
        }

        void SetNegativeValue(float value)
        {
            float x = value / limit;
            int i = (x > 0) ? 0 : 1;
            Slider[] act = sliders[i];
            Slider[] deact = sliders[1 - i];
            foreach (var s in deact)
            {
                s.value = 0;
            }
            x = Math.Abs(x);
            if (x < 1)
            {
                current = normal;
                act[0].value = x;
                return;
            }
            act[0].value = 1;
            x -= 1;
            if (x > 1)
            {
                x = 1;
            }
            current = exceed;
            act[1].value = x;
            sign = Sign.negative;
        }

        void SetPositiveValue(float value)
        {
            float x = value / limit;
            if (x < 1)
            {
                current = normal;
                left.value = x;
                return;
            }
            left.value = 1;
            x -= 1;
            if (x > 1)
            {
                x = 1;
            }
            current = exceed;
            right.value = x;
        }

        void CreatePositive()
        {
            exceeds = () =>
            {
                float x = (float)currentValue / limit;
                return x > 1;
            };
            var c = components;
 //           RectTransform tr = gameObject.GetComponent<RectTransform>();
  //          var tt = gameObject.GetComponentsInChildren<RectTransform>();
            left = c["SliderLeft"][1] as Slider;
            right = c["SliderRight"][1] as Slider;
            Vector3 vp = new Vector3();
            left.fillRect.sizeDelta = new Vector2(0, 0);
            // left.fillRect.position = left...position;
            left.GetComponentInChildren<Image>().color = normal;
            // right.fillRect.sizeDelta = new Vector2(0, 0);
            //       right.fillRect.position = vp;
            right.value = 0;
            right.GetComponentInChildren<Image>().color = exceed;

            setFloatValue = SetPositiveValue;
            disableSliders = (bool b) =>
            {
                left.enabled = b;
                right.enabled = b;
            };
        }

        void CreateNegative()
        {
            exceeds = () =>
            {
                float x = (float)currentValue / limit;
                return Math.Abs(x) > 1;
            };

            var c = components;
            //           RectTransform tr = gameObject.GetComponent<RectTransform>();
            //          var tt = gameObject.GetComponentsInChildren<RectTransform>();
            sliders = new Slider[][]
            {
                new Slider[] { 
                    c["SliderRightLeft"][1] as Slider,
                c["SliderRightRight"][1] as Slider },
                                
                new Slider[] { 
                    c["SliderLeftRight"][1] as Slider, c["SliderLeftLeft"][1] as Slider,  }

        };
            Color[] colors = { normal, exceed };
            foreach (var s in sliders)
            {
                for (int i = 0; i < 2; i++)
                {
                    var sl = s[i];
                    sl.GetComponentInChildren<Image>().color = colors[i];
                    sl.fillRect.sizeDelta = Vector2.zero;
                }
            }
            setFloatValue = SetNegativeValue;
            disableSliders = (bool b)  =>
            {
                foreach (var ss in sliders)
                {
                    foreach (var s in ss)
                    {
                        s.gameObject.SetActive(b);
                    }
                }
            };
        }

        protected override void PostSetGlobal(string str)
        {
          
        }

        protected override void PostSetActive()
        {
            component.gameObject.SetActive(isActive);
        }


        protected override void PostSet()
        {
            Value = (double)obj;
        }



        #endregion


    }
}
