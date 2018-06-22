using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool returnValue = true;
            try
            {
                StreamWriter sr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);
                sr.WriteLine(texto);
                sr.Close();
            }
            catch (Exception)
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}