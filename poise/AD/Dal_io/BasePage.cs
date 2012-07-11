using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.IO.Compression;

namespace Dal_io
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        protected override void SavePageStateToPersistenceMedium(object pageViewState)
        {
          
            MemoryStream ms = new MemoryStream();
            LosFormatter m_formatter = new LosFormatter();
            m_formatter.Serialize(ms, pageViewState);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string viewStateString = sr.ReadToEnd();
            byte[] ViewStateBytes = Convert.FromBase64String(viewStateString);
            ViewStateBytes = ViewStateCompression.Compress(ViewStateBytes);
            Session["ViewState"] = Convert.ToBase64String(ViewStateBytes);
            ms.Close();
            return;
        }

        // 序列化ViewState
        protected override object LoadPageStateFromPersistenceMedium()
        {
            object viewStateBag;
            string m_viewState = (string)Session["ViewState"];
            byte[] ViewStateBytes = Convert.FromBase64String(m_viewState);
            ViewStateBytes = ViewStateCompression.Decompress(ViewStateBytes);
            LosFormatter m_formatter = new LosFormatter();
            try
            {
                viewStateBag = m_formatter.Deserialize(Convert.ToBase64String(ViewStateBytes));
            }
            catch (Exception ex)
            {
                //Log.Insert( "页面Viewtate是空。" );
                viewStateBag = string.Empty;
            }
            return viewStateBag;
        }
    }
    public class ViewStateCompression
    {
        public ViewStateCompression()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        // 压缩
        public static byte[] Compress(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            GZipStream gzip = new GZipStream(output,
            CompressionMode.Compress, true);
            gzip.Write(data, 0, data.Length);
            gzip.Close();
            return output.ToArray();
        }

        // 解压缩
        public static byte[] Decompress(byte[] data)
        {
            MemoryStream input = new MemoryStream();
            input.Write(data, 0, data.Length);
            input.Position = 0;
            GZipStream gzip = new GZipStream(input,
            CompressionMode.Decompress, true);
            MemoryStream output = new MemoryStream();
            byte[] buff = new byte[64];
            int read = -1;
            read = gzip.Read(buff, 0, buff.Length);
            while (read > 0)
            {
                output.Write(buff, 0, read);
                read = gzip.Read(buff, 0, buff.Length);
            }
            gzip.Close();
            return output.ToArray();
        }
    }
}
