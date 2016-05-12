using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections;

namespace ChessGame
{
    public static class SaveLoadHistory
    {
        private static BinaryFormatter formater = new BinaryFormatter();

        private static FileStream InOutPut;
        
        public static void Save(ArrayList historyVal)
        {
            SaveFileDialog fileChooser = new SaveFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName;

            fileChooser.CheckFileExists = false;

            if (result == DialogResult.Cancel)
                return;

            fileName = fileChooser.FileName;

            if (fileName == "" || fileName == null)
                MessageBox.Show("Error");
            else
            {
                try
                {
                    InOutPut = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                    formater.Serialize(InOutPut, historyVal);
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show("error");
                }
            }
            InOutPut.Close();
        }

        public static ArrayList Load()
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName;
            ArrayList list = new ArrayList();

            if (result == DialogResult.Cancel)
                return null;

            fileName = fileChooser.FileName;

            if (fileName == "" || fileName == null)
                MessageBox.Show("Error");
            else
            {
                InOutPut = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                list = ((ArrayList)formater.Deserialize(InOutPut));
            }
            InOutPut.Close();
            return list;
        }
    }
}
