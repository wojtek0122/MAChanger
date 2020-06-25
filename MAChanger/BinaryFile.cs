using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MAChanger
{
    class BinaryFile
    {        
        public byte ConvertStringToByte(string Value)
        {
            byte number = 0;
            int result = 0;

            switch (Value[0])
            {
                case '0': { result += 0; break; };
                case '1': { result += 1 * 16; break; };
                case '2': { result += 2 * 16; break; };
                case '3': { result += 3 * 16; break; };
                case '4': { result += 4 * 16; break; };
                case '5': { result += 5 * 16; break; };
                case '6': { result += 6 * 16; break; };
                case '7': { result += 7 * 16; break; };
                case '8': { result += 8 * 16; break; };
                case '9': { result += 9 * 16; break; };
                case 'A': { result += 10 * 16; break; };
                case 'B': { result += 11 * 16; break; };
                case 'C': { result += 12 * 16; break; };
                case 'D': { result += 13 * 16; break; };
                case 'E': { result += 14 * 16; break; };
                case 'F': { result += 15 * 16; break; };
            };

            switch (Value[1])
            {
                case '0': { result += 0; break; };
                case '1': { result += 1; break; };
                case '2': { result += 2; break; };
                case '3': { result += 3; break; };
                case '4': { result += 4; break; };
                case '5': { result += 5; break; };
                case '6': { result += 6; break; };
                case '7': { result += 7; break; };
                case '8': { result += 8; break; };
                case '9': { result += 9; break; };
                case 'A': { result += 10; break; };
                case 'B': { result += 11; break; };
                case 'C': { result += 12; break; };
                case 'D': { result += 13; break; };
                case 'E': { result += 14; break; };
                case 'F': { result += 15; break; };
            };

            number = Convert.ToByte(result);

            return number;
        }

        public void ChangeBinary(string Filename, string mac)
        {
            string a1 = mac.Substring(0, 2);
            string a2 = mac.Substring(2, 2);
            string a3 = mac.Substring(4, 2);
            string a4 = mac.Substring(6, 2);
            string a5 = mac.Substring(8, 2);
            string a6 = mac.Substring(10, 2);

            using (var stream = new FileStream(Filename, FileMode.Open, FileAccess.ReadWrite))
            {
                stream.Position = 4096;
                stream.WriteByte(ConvertStringToByte(a1));

                stream.Position = 4097;
                stream.WriteByte(ConvertStringToByte(a2));

                stream.Position = 4098;
                stream.WriteByte(ConvertStringToByte(a3));

                stream.Position = 4099;
                stream.WriteByte(ConvertStringToByte(a4));

                stream.Position = 4100;
                stream.WriteByte(ConvertStringToByte(a5));

                stream.Position = 4101;
                stream.WriteByte(ConvertStringToByte(a6));
            }

        }

        public string ReadBinary(string Filename)
        {
            string value = null;

            using (var stream = new FileStream(Filename, FileMode.Open, FileAccess.ReadWrite))
            {
                stream.Position = 4096;
                int a1 = stream.ReadByte();
                stream.Position = 4097;
                int a2 = stream.ReadByte();
                stream.Position = 4098;
                int a3 = stream.ReadByte();
                stream.Position = 4099;
                int a4 = stream.ReadByte();
                stream.Position = 4100;
                int a5 = stream.ReadByte();
                stream.Position = 4101;
                int a6 = stream.ReadByte();
                value = String.Format("#{0:X}-{1:X}-{2:X}-{3:X}-{4:X}-{5:X}", a1, a2, a3, a4, a5, a6);
            }

            return value;
        }
    }
}
