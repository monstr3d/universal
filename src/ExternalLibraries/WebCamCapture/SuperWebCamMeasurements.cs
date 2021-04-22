using CategoryTheory;
using Diagram.UI;
using DataPerformer.Interfaces;
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebCamCapture
{
    public abstract class SuperWebCamMeasurements : CategoryObject, ICalculationReason, 
        ISerializable
    {
        #region Fields

        #region Object variables

        int width = 640;

        int height = 480;

        private int m_CapHwnd;


        Func<object> parameter;

        Func<object> own;

        protected Bitmap bitmap;

        protected string calculationReason = "";

        protected bool isUpdated = false;

        protected Action update = () => { };

        event Action onStart = () => { };

        event Action onStop = () => { };

   
        bool isEnabled;

        #endregion

        #region API Constants

        //Esas constantes são predefinidas pelo SO

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GT_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        #endregion


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected SuperWebCamMeasurements()
        {
            parameter = Get;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SuperWebCamMeasurements(SerializationInfo info, StreamingContext context)
            : this()
        {
            width = info.GetInt32("Width");
            height = info.GetInt32("Height");
        }

        #endregion

        #region ICalculationReason Members

        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
                SetCalculationReason();
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", width);
            info.AddValue("Height", height);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Bitmap
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                return bitmap;
            }
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Sets calculation reason
        /// </summary>
        protected abstract void SetCalculationReason();

        /// <summary>
        /// Gets the bitmap
        /// </summary>
        /// <returns></returns>
        protected object Get()
        {
            return bitmap;
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        protected void Update()
        {
            SendMessage(m_CapHwnd, WM_CAP_GT_FRAME, 0, 0);

            SendMessage(m_CapHwnd, WM_CAP_COPY, 0, 0);

            OpenClipboard(m_CapHwnd);

            IntPtr img = GetClipboardData(2);

            CloseClipboard();

            //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m_Width, m_Height);

            //using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
            //{
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            //    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

            //    g.DrawImage(Image.FromHbitmap(img), 0, 0, m_Width, m_Height);
            //}

            //ImgWebCam.Image = bmp;

            System.Windows.Forms.IDataObject tempObj = System.Windows.Forms.Clipboard.GetDataObject();
            bitmap = (Bitmap)tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);
            bitmap = new Bitmap(bitmap);


            System.Windows.Forms.Application.DoEvents();

        }


        #region Object Members

        /// <summary>
        /// Statrs itself
        /// </summary>
        protected void Start()
        {
            if (!calculationReason.Equals(StaticExtensionEventInterfaces.Realtime))
            {
                return;
            }
            try
            {

                Stop();


               // System.Windows.Forms.Control c = this.Object as System.Windows.Forms.Control;
                m_CapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, width, height, 0, 0);

                //  c.Handle.ToInt32(), 0);

                System.Windows.Forms.Application.DoEvents();

                SendMessage(m_CapHwnd, WM_CAP_CONNECT, 0, 0);

            }
            catch (Exception ex)
            {
                ex.ShowError();
                Stop();
            }
        }

        /// <summary>
        /// Stops itself
        /// </summary>
        protected void Stop()
        {
            if (!calculationReason.Equals(StaticExtensionEventInterfaces.Realtime))
            {
                return;
            }

            try
            {

                System.Windows.Forms.Application.DoEvents();

                SendMessage(m_CapHwnd, WM_CAP_DISCONNECT, 0, 0);

                CloseClipboard();

            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion



        #endregion

        #region Private Members

        #region API Declarations

        //Abaixo tremos todas as chamadas das APIs do Sistema Operacional Windows.
        //Essas chamadas fazem a interface do nosso controle com a WebCam e com o SO.

        //Esta chamada é uma das mais importantes e é vital para o funcionamento do SO. 
        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        //Esta API cria a instância da webcam para que possamos acessa-la.
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hwndParent, int nID);

        //Esta API abre a área de tranferência para que possamos buscar os dados da webcam.
        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        //Esta API limpa a área de transferência.
        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();

        //Esta API fecha a área de tranferência após utilização.
        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();

        //Esta API recupera os dados da área de tranferência para a utilização.
        [DllImport("user32.dll")]
        extern static IntPtr GetClipboardData(uint uFormat);

        #endregion

        #endregion

    }
}