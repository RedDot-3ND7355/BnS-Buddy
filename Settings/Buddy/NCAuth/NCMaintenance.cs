using Revamped_BnS_Buddy.Functions;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Revamped_BnS_Buddy.Settings.Buddy.NCAuth
{
    class NCMaintenance
    {
        public bool In_Maintenance = Maintenance();
        private static MetroFramework.Controls.MetroComboBox CurrentSelection = Form1.CurrentForm.metroComboBox1;
        private static bool Debugging = Form1.CurrentForm.Debugging;

        private static bool Maintenance()
        {
            try
            {
                string a = CurrentSelection.SelectedItem.ToString();
                string text = ServerValues.GetServerValues(a, "Login")[0];
                string text2 = ServerValues.GetServerValues(a, "Login")[1];
                #region maintenace check
                int port = 27500;
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write((short)0);
                binaryWriter.Write((short)4);
                binaryWriter.Write((byte)10);
                binaryWriter.Write((byte)text2.Length);
                binaryWriter.Write(Encoding.ASCII.GetBytes(text2));
                binaryWriter.BaseStream.Position = 0L;
                binaryWriter.Write((short)memoryStream.Length);
                NetworkStream stream = new TcpClient(text, port).GetStream();
                stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                binaryWriter.Close();
                memoryStream.Close();
                memoryStream = new MemoryStream();
                BinaryReader binaryReader = new BinaryReader(memoryStream);
                byte[] array = new byte[1024];
                int num = 0;
                do
                {
                    num = stream.Read(array, 0, array.Length);
                    if (num > 0)
                    {
                        memoryStream.Write(array, 0, num);
                    }
                }
                while (num == array.Length);
                memoryStream.Position = 9L;
                binaryReader.ReadBytes(binaryReader.ReadByte() + 1);
                bool flag = binaryReader.ReadBoolean();
                stream.Close();
                binaryReader.Close();
                memoryStream.Close();
                if (!flag && !Debugging)
                {
                    Prompt.Popup("The Game Server is currently in maintenance, please try again later.");
                    Form1.CurrentForm.metroButton1.Enabled = true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure your ip isn't blocked.");
                if (Debugging)
                {
                    Prompt.Popup(ex.ToString());
                }
                Form1.CurrentForm.metroButton1.Enabled = true;
                return false;
            }
            #endregion
        }

    }
}
