using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace QRGenerator.Helper
{
    public class GeneradorHelper
    {
        public GeneradorHelper()
        {

        }
        public Byte[] GererarQR()
        {
            WiFi wifi = new WiFi("nombredelared", "lapass", WiFi.Authentication.WPA);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(wifi, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeAsByteArray;

            using (var qrBitmap = new BitmapByteQRCode(qrCodeData))
            {
                qrCodeAsByteArray = qrCode.GetGraphic(20, "#FF0000", "#FFFFFF");

                MemoryStream stream = new MemoryStream();
                qrCodeAsByteArray.Save(stream, ImageFormat.Png);
                byte[] result = stream.ToArray();
                return result;
            }


        }

    }


}
