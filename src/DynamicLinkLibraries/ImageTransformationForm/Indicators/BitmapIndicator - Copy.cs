using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageTransformations.Forms;

using DataPerformer.Interfaces;

namespace ImageTransformations.Indicators
{
    class BitmapIndicator : IMeasurementObjectFactory
    {
        object IMeasurementObjectFactory.this[IMeasurement measure]
        {
            get
            {
                return Accept(measure);
            }
        }

        object IMeasurementObjectFactory.this[string name, IMeasurement measure]
        {
            get
            {
                Form f = Accept(measure);
                if (f != null)
                {
                    f.Text = name;
                }
                return f;
            }
        }

        Form Accept(IMeasurement m)
        {
            object type = m.Type;
            if (type.Equals(typeof(System.Drawing.Bitmap)))
            {
                return new FormPureBitmap(m);
            }
            return null;
        }
    }
}
