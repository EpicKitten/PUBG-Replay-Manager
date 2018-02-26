using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBG_Replay_Manager
{
    class Utils
    {
        public static string UE4StringSerializer(string file_path, int encoded_offset = 0)
        {
            FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);

            byte[] length_bytes = new byte[4];
            fs.Read(length_bytes, 0, length_bytes.Length);
            int bytestoread = BitConverter.ToInt32(length_bytes, 0);

            byte[] unencodedbytes = new byte[bytestoread];
            for (int i = 0; i < bytestoread; i++)
            {
                int encodedbyte = fs.ReadByte();

                if (encodedbyte > 0) //if the byte is zero (techinally should only be handled at the end per numinit (https://github.com/numinit)'s specifications but I'm lazy
                {
                    unencodedbytes[i] = (byte)(encodedbyte + encoded_offset);
                }
            }
            fs.Close();

            int stringBytesLength = unencodedbytes[unencodedbytes.Length - 1] == 0 ? unencodedbytes.Length - 1 : unencodedbytes.Length; // Skip last byte if its zero
            return Encoding.UTF8.GetString(unencodedbytes, 0, stringBytesLength); // take all the bytes, put the array into UTF8 encoding and return it
        }
        
        public static double GetDirectorySize(string directory)
        {
            double foldersize = 0;
            if (Directory.Exists(directory))
            {
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    GetDirectorySize(dir);
                }

                foreach (FileInfo file in new DirectoryInfo(directory).GetFiles())
                {
                    foldersize += file.Length;
                }
            }
            
            return foldersize;
        }
    }
}
