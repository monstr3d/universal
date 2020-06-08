using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Standard
{
    public class SliderWrapper
    {
        #region Fields

        public float limit;

        public float scale;

        Color current;

        // public float ratio = 0.5f;

        public Color normal = new Vector4(0, 1, 0, 1);

        public Color exceed = new Vector4(1, 0, 0, 1);

        Action update;

        public string desktop = "";

        public string pararmeter = "";

        Dictionary<string, List<Component>> components;

        Component component;

        Func<double> output;

        float currentValue;

        Slider left;

        Slider right;

        GameObject gameObject;

        Action<float> setValue;

        string initialText = "";

        Text text;

        string format = "0.00";

        Action updateText;

        Slider[][] sliders;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="component">Component</param>
        /// <param name="scale">Scale</param>
        /// <param name="limit">Limit</param>
        /// <param name="output">Output</param>
        /// <param name="normal">Normal color</param>
        /// <param name="exceed">Exceed color</param>
        /// <param name="format">Format</param>
        public SliderWrapper(Component component,
          float scale, float limit, Func<double> output, Color normal, Color exceed, string format) :
            this(component, scale, limit, output)
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

        public SliderWrapper(Component component,
            float scale, float limit, Func<double> output = null)
        {
            this.component = component;
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
                setValue(GetValue(output()));
            };

        }

        #endregion

        #region Public Members

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
                setValue(GetValue(value));
                updateText?.Invoke();
            }
        }

        void UpdateText()
        {
            if (text.color != current)
            {
                text.color = current;
            }
            text.text = initialText + currentValue.ToString(format);
        }


        #endregion

        #region Private Members


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

            setValue = SetPositiveValue;
        }

        void CreateNegative()
        {
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
            setValue = SetNegativeValue;
        }



        #endregion



    }
}
